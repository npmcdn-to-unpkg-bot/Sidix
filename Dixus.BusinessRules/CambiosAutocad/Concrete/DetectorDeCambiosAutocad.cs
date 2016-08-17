using Dixus.BusinessRules.CambiosAutocad.Abstract;
using Dixus.BusinessRules.CambiosAutocad.Entidades;
using Dixus.Entidades;
using Dixus.Entidades.Gis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.CambiosAutocad.Concrete
{

    public class DetectorDeCambiosAutocad : IDetectorDeCambiosAutocad
    {
        private IEnumerable<Fraccion> _fraccionesActuales;
        private IEnumerable<FeatureFraccion> _fraccionesNuevas;
        private IEnumerable<Vialidad> _vialidadesActuales;
        private IEnumerable<VialPoly> _vialidadesNuevas;

        public DetectorDeCambiosAutocad(IEnumerable<Fraccion> fraccionesActuales, IEnumerable<FeatureFraccion> fraccionesNuevas, IEnumerable<Vialidad> vialidadesActuales, IEnumerable<VialPoly> vialidadesNuevas)
        {
            _fraccionesActuales = fraccionesActuales;
            _fraccionesNuevas = fraccionesNuevas;
            _vialidadesActuales = vialidadesActuales;
            _vialidadesNuevas = vialidadesNuevas;
        }

        public async Task<ResumenDeCambiosAutocad> ObtenerResumenDeCambios()
        {
            var cambiosFracciones = ObtenerResumenDeCambiosEnFracciones();
            var cambiosVialidades = ObtenerResumenDeCambiosEnVialidades();

            return await Task.WhenAll(cambiosFracciones, cambiosVialidades)
                .ContinueWith(task =>
                {
                    var rf = cambiosFracciones.Result;
                    var rv = cambiosVialidades.Result;
                    return new ResumenDeCambiosAutocad()
                    {
                        FraccionesSinModificacionAforma = rf.FraccionesSinModificacionAforma,
                        FraccionesSidixQueNoTienenContraparte = rf.FraccionesSidixQueNoTienenContraparte,
                        FraccionesAutocadQueNoTienenContraparte = rf.FraccionesAutocadQueNoTienenContraparte,

                        VialidadesSinModificacionAforma = rv.VialidadesSinModificacionAforma,
                        VialidadesSidixQueNoTienenContraparte = rv.VialidadesSidixQueNoTienenContraparte,
                        VialidadesAutocadQueNoTienenContraparte = rv.VialidadesAutocadQueNoTienenContraparte
                    };
                });
        }
        public bool ChecarSiModeloHaCambiado()
        {
            
            if (_fraccionesActuales.Count() != _fraccionesNuevas.Count()) return true;
            if (_vialidadesActuales.Count() != _vialidadesNuevas.Count()) return true;

            // CHECAR PRIMERO SI FRACCIONES HAN CAMBIADO, SI SÍ, REGRESAR TRUE
            IEnumerable<InfoComparableDeFraccion> terrenosActuales = _fraccionesActuales.Select(
            fr => new InfoComparableDeFraccion()
            {
                Nombre = fr.Nombre,
                Id = fr.FraccionId,
                Geometria = fr.Geometria,
                UsoDeSueloId = fr.TipoDeSueloId
            });
            IEnumerable<InfoComparableDeFraccion> terrenosNuevos = _fraccionesNuevas.Select(
            fr => new InfoComparableDeFraccion()
            {
                Nombre = fr.Nombre,
                Id = (int)fr.FeatId,
                Geometria = fr.Geometry,
                UsoDeSueloId = fr.ObtenerUsoDeSueloId()
            });
            HashSet<InfoComparableDeFraccion> terrenosActualesHashSet = new HashSet<InfoComparableDeFraccion>(terrenosActuales, new ComparadorDeFraccionesCompleto());
            if(!terrenosActualesHashSet.SetEquals(terrenosNuevos))
            {
                return true;
            }
            
            // SI FRACCIONES NO HAN CAMBIADO, COMPARAR VIALIDADES          
            IEnumerable<InfoComparableDeVialidad> vialidadesActuales = _vialidadesActuales.Select(
            vial => new InfoComparableDeVialidad()
            {
                Nombre = vial.Nombre,
                Id = vial.VialidadId,
                Geometria = vial.Geometria,
                Tramo = vial.Tramo
            });
            IEnumerable<InfoComparableDeVialidad> vialidadesNuevas = _vialidadesNuevas.Select(
            vial => new InfoComparableDeVialidad()
            {
                Nombre = vial.ViaNombre,
                Id = (int)vial.FeatId,
                Geometria = vial.Geom,
                Tramo = vial.ViaTramo
            });
            HashSet<InfoComparableDeVialidad> vialidadesActualesHashSet = new HashSet<InfoComparableDeVialidad>(vialidadesActuales, new ComparadorDeVialidadesCompleto());
            if(!vialidadesActualesHashSet.SetEquals(vialidadesNuevas))
            {
                return true;
            }

            // SI NADA HA CAMBIADO, REGRESAR FALSE
            return false;

        }

        private async Task<ResumenDeCambiosFraccionesAutocad> ObtenerResumenDeCambiosEnFracciones()
        {
            return await Task.Run(() =>
            {
                List<ModificacionAPropiedadesDeFraccion> fraccionesSinModificacionAforma = new List<ModificacionAPropiedadesDeFraccion>();
                List<Fraccion> fraccionesSidixQueNoTienenContraparte = new List<Fraccion>();
                IEnumerable<FeatureFraccion> fraccionesAutocadQueNoTienenContraparte = new List<FeatureFraccion>();

                foreach (var fraccSidix in _fraccionesActuales)
                {
                    bool tieneContraparte = false;
                    foreach (var fraccAutocad in _fraccionesNuevas)
                    {
                        if (fraccSidix.Geometria.SpatialEquals(fraccAutocad.Geometry))
                        {
                            fraccionesSinModificacionAforma.Add(new ModificacionAPropiedadesDeFraccion(fraccSidix, fraccAutocad));
                            tieneContraparte = true;
                            break;
                        }
                    }
                    if (!tieneContraparte) fraccionesSidixQueNoTienenContraparte.Add(fraccSidix);
                }

                if (fraccionesSinModificacionAforma != null && fraccionesSinModificacionAforma.Count > 0)
                {
                    fraccionesAutocadQueNoTienenContraparte = _fraccionesNuevas.Except(fraccionesSinModificacionAforma.Select(x => x.FraccionAutocad));
                }
                else
                {
                    fraccionesAutocadQueNoTienenContraparte = _fraccionesNuevas;
                }

                return new ResumenDeCambiosFraccionesAutocad()
                {
                    FraccionesSinModificacionAforma = fraccionesSinModificacionAforma,
                    FraccionesSidixQueNoTienenContraparte = fraccionesSidixQueNoTienenContraparte,
                    FraccionesAutocadQueNoTienenContraparte = fraccionesAutocadQueNoTienenContraparte,
                };
            });
        }
        private async Task<ResumenDeCambiosVialidadesAutocad> ObtenerResumenDeCambiosEnVialidades()
        {
            return await Task.Run(() =>
            {
                List<ModificacionAPropiedadesDeVialidad> vialidadesSinModificacionAforma = new List<ModificacionAPropiedadesDeVialidad>();
                List<Vialidad> vialidadesSidixQueNoTienenContraparte = new List<Vialidad>();
                IEnumerable<VialPoly> vialidadesAutocadQueNoTienenContraparte = new List<VialPoly>();

                Debug.WriteLine("Empezando a comparar vialidades sidix con autocad");

                foreach (var vialSidix in _vialidadesActuales)
                {
                    bool tieneContraparte = false;
                    foreach (var vialAutocad in _vialidadesNuevas)
                    {
                        if (vialSidix.Geometria.SpatialEquals(vialAutocad.Geom))
                        {
                            vialidadesSinModificacionAforma.Add(new ModificacionAPropiedadesDeVialidad(vialSidix, vialAutocad));
                            tieneContraparte = true;
                            break;
                        }
                    }
                    if (!tieneContraparte) vialidadesSidixQueNoTienenContraparte.Add(vialSidix);
                }

                Debug.WriteLine("Acabo de comparar vialidades sidix con autocad");

                if (vialidadesSinModificacionAforma != null && vialidadesSinModificacionAforma.Count > 0)
                {
                    vialidadesAutocadQueNoTienenContraparte = _vialidadesNuevas.Except(vialidadesSinModificacionAforma.Select(x => x.VialidadAutocad));
                }
                else
                {
                    vialidadesAutocadQueNoTienenContraparte = _vialidadesNuevas;
                }

                Debug.WriteLine("Acabo de sacar lista de vial autocad que no tienen contraparte");

                return new ResumenDeCambiosVialidadesAutocad()
                {
                    VialidadesSinModificacionAforma = vialidadesSinModificacionAforma,
                    VialidadesSidixQueNoTienenContraparte = vialidadesSidixQueNoTienenContraparte,
                    VialidadesAutocadQueNoTienenContraparte = vialidadesAutocadQueNoTienenContraparte,
                };
            });

        }

        public IEnumerable<Fraccion> ObtenerSetDeFraccionesActuales()
        {
            return _fraccionesActuales;
        }
        public IEnumerable<FeatureFraccion> ObtenerSetDeFraccionesNuevas()
        {
            return _fraccionesNuevas;
        }
        public IEnumerable<Vialidad> ObtenerSetDeVialidadesActuales()
        {
            return _vialidadesActuales;
        }
        public IEnumerable<VialPoly> ObtenerSetDeVialidadesNuevas()
        {
            return _vialidadesNuevas;
        }
    }

    
}
