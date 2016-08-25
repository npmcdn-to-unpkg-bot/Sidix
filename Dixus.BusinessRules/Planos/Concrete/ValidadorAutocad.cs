using Dixus.BusinessRules.Planos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dixus.Entidades.Gis;
using Dixus.BusinessRules.Planos.Entidades;
using Dixus.Entidades;
using Dixus.BusinessRules.Planos.Entidades.Validacion;

namespace Dixus.BusinessRules.Planos.Concrete
{
    public class ValidadorAutocad : IValidadorAutocad
    {
        private IEnumerable<FeatureFraccion> _Fracciones;
        private IEnumerable<VialPoly> _Vialidades;
        public ValidadorAutocad(IEnumerable<FeatureFraccion> fracciones, IEnumerable<VialPoly> vialidades)
        {
            _Fracciones = fracciones;
            _Vialidades = vialidades;
        }

        public async Task<bool> ChecarSiModeloAutocadEsValido(OpcionesDeValidacionAutocad opciones)
        {
            var autocadTieneSuperficieValida =
                opciones.ValidarSuperficieTotal ?
                AutocadTieneSuperficieValida(opciones.AreaTotalDelProyectoEnMetros, opciones.ToleranciaEnM2ParaProyecto) :
                Task.Run(() => true);

            var todasLasGoometriasSonPoligonos =
                opciones.ValidarQueTodasLasGeometriasSeanPoligonos ?
                TodasLasGoometriasSonPoligonos() :
                Task.Run(() => true);

            var todosLosPoligonosEstanCerrados =
                opciones.ValidarQuePoligonosEstenCerrados ?
                TodosLosPoligonosEstanCerrados() :
                Task.Run(() => true);

            var todosLosPoligonosSonValidos =
                opciones.ValidarQuePoligonosSeanValidos ?
                TodosLosPoligonosSonValidos() :
                Task.Run(() => true);

            var niUnPoligonoSeSobrepone =
                opciones.ValidarQuePoligonosNoSeSobrepongan ?
                NiUnPoligonoSeSobrepone(opciones.TamañoMaximoDeSobreposiciones) :
                Task.Run(() => true);

            return await Task.WhenAll(autocadTieneSuperficieValida, todasLasGoometriasSonPoligonos, todosLosPoligonosEstanCerrados, todosLosPoligonosSonValidos, niUnPoligonoSeSobrepone)
                .ContinueWith(task =>
                {
                    bool esValido = true;
                    bool[] resultadosDeValidaciones = task.Result;
                    foreach (var val in resultadosDeValidaciones)
                    {
                        if (val == false)
                        {
                            esValido = false;
                        }
                    }
                    return esValido;
                });
        }

        // AREA
        public async Task<bool> AutocadTieneSuperficieValida(double areaQueDeberiaTenerElProyecto, double margenDeErrorEnMetrosCuadrados)
        {
            return await Task.Run(() =>
            {
                double minimoValorAceptado = areaQueDeberiaTenerElProyecto - margenDeErrorEnMetrosCuadrados;
                double maximoValorAceptado = areaQueDeberiaTenerElProyecto + margenDeErrorEnMetrosCuadrados;

                double areaTotalAutocad = _Fracciones.Sum(f => f.Geometry.Area.HasValue ? f.Geometry.Area.Value : 0) +
                                            _Vialidades.Sum(v => v.Geom.Area.HasValue ? v.Geom.Area.Value : 0);

                var superficieEsValida = areaTotalAutocad >= minimoValorAceptado && areaTotalAutocad <= maximoValorAceptado;
                return superficieEsValida;
            });
        }

        // POLIGONOS NO SE SOBREPONEN
        public async Task<bool> NiUnPoligonoSeSobrepone(double tamañoMaximoDeSobreposiciones)
        {
            var areasSobrepuestas = await ObtenerAreasSobrepuestas(tamañoMaximoDeSobreposiciones);
            return areasSobrepuestas.Count() == 0;
        }
        public async Task<IEnumerable<GeometriaSobrepuesta>> ObtenerAreasSobrepuestas(double tamañoMaximoPermitidoDeSobreposiciones)
        {
            return await Task.Run(() =>
            {
                List<GeometriaSobrepuesta> geometriasSobrepuestas = new List<GeometriaSobrepuesta>();
                List<InfoComparableDePoligono> poligonos = new List<InfoComparableDePoligono>();

                poligonos.AddRange(_Fracciones.Select(f => new InfoComparableDePoligono { Nombre = f.Nombre, Geometria = f.Geometry }));
                poligonos.AddRange(_Vialidades.Select(f => new InfoComparableDePoligono { Nombre = f.ViaNombre, Geometria = f.Geom }));

                int numeroDeGeometrias = poligonos.Count;
                for (int i = 0; i < numeroDeGeometrias; i++)
                {
                    for (int j = i + 1; j < numeroDeGeometrias; j++)
                    {
                        var elem1 = poligonos.ElementAt(i);
                        var elem2 = poligonos.ElementAt(j);
                        // Se checa si se intersectan para saber si ocupan el mismo espacio en almenos un punto o espacio. Pero luego se excluyen las que solo se tocan, sin que sus interiores se intersecten
                        if (elem1.Geometria.Intersects(elem2.Geometria) && !elem1.Geometria.Touches(elem2.Geometria))
                        {
                            var interseccion = elem1.Geometria.Intersection(elem2.Geometria);
                            if (interseccion.Area.HasValue && interseccion.Area.Value > tamañoMaximoPermitidoDeSobreposiciones)
                            {
                                geometriasSobrepuestas.Add(new GeometriaSobrepuesta() { Geom = interseccion, InfoPoligono1 = elem1, InfoPoligono2 = elem2 });
                            }
                        }
                    }
                }
                return geometriasSobrepuestas;
            });
        }

        // GEOMTRIAS SON POLIGONOS
        public async Task<bool> TodasLasGoometriasSonPoligonos()
        {
            var geometriasQueNoSonPoligonos = await ObtenerGeometriasQueNoSonPoligonos();
            return geometriasQueNoSonPoligonos.EstaVacio;
        }
        public async Task<PoligonosAutocadQueNoPasaronValidacion> ObtenerGeometriasQueNoSonPoligonos()
        {
            return await Task.Run(() =>
            {
                PoligonosAutocadQueNoPasaronValidacion geometriasQueNoSonPoligonos = new PoligonosAutocadQueNoPasaronValidacion();
                foreach (var fracc in _Fracciones)
                {
                    if (fracc.Geometry.SpatialTypeName != "Polygon") geometriasQueNoSonPoligonos.Fracciones.Add(fracc);
                }
                foreach (var vial in _Vialidades)
                {
                    if (vial.Geom.SpatialTypeName != "Polygon") geometriasQueNoSonPoligonos.Vialidades.Add(vial);
                }
                return geometriasQueNoSonPoligonos;
            });
        }

        // POLIGONOS SON VALIDOS
        public async Task<bool> TodosLosPoligonosSonValidos()
        {
            var poligonosInvalidos = await ObtenerPoligonosInvalidos();
            return poligonosInvalidos.EstaVacio;
        }
        public async Task<PoligonosAutocadQueNoPasaronValidacion> ObtenerPoligonosInvalidos()
        {
            return await Task.Run(() =>
            {
                PoligonosAutocadQueNoPasaronValidacion poligonosInvalidos = new PoligonosAutocadQueNoPasaronValidacion();
                foreach (var fracc in _Fracciones)
                {
                    if (!fracc.Geometry.IsValid) poligonosInvalidos.Fracciones.Add(fracc);
                }
                foreach (var vial in _Vialidades)
                {
                    if (!vial.Geom.IsValid) poligonosInvalidos.Vialidades.Add(vial);
                }
                return poligonosInvalidos;
            });
        }

        // POLIGONOS ESTAN CERRADOS
        public async Task<bool> TodosLosPoligonosEstanCerrados()
        {
            var poligonosNoCerrados = await ObtenerPoligonosNoCerrados();
            return poligonosNoCerrados.EstaVacio;
        }
        public async Task<PoligonosAutocadQueNoPasaronValidacion> ObtenerPoligonosNoCerrados()
        {
            return await Task.Run(() =>
            {
                PoligonosAutocadQueNoPasaronValidacion poligonosNoCerrados = new PoligonosAutocadQueNoPasaronValidacion();
                foreach (var fracc in _Fracciones)
                {
                    if (!fracc.Geometry.IsClosed.HasValue || !fracc.Geometry.IsClosed.Value)
                        poligonosNoCerrados.Fracciones.Add(fracc);
                }
                foreach (var vial in _Vialidades)
                {
                    if (!vial.Geom.IsClosed.HasValue || !vial.Geom.IsClosed.Value)
                        poligonosNoCerrados.Vialidades.Add(vial);
                }
                return poligonosNoCerrados;
            });
        }

        // FRACCIONES SON MODIFICABLES
        public async Task<bool> TodasLasFraccionesQueCambiaranSonModificables(IEnumerable<Fraccion> fraccionesQueCambiaran)
        {
            var fraccionesInvalidas = await ObtenerFraccionesQueCambiaranQueSonInmodificables(fraccionesQueCambiaran);
            return fraccionesInvalidas.Count() == 0;
        }
        public async Task<IEnumerable<Fraccion>> ObtenerFraccionesQueCambiaranQueSonInmodificables(IEnumerable<Fraccion> fraccionesQueCambiaran)
        {
            return await Task.Run(() =>
            {
                return fraccionesQueCambiaran.Where(fracc =>
                   fracc.SubdivisionLegal != null &&
                   (fracc.SubdivisionLegal.Estatus == EstatusDeSubdivision.Vendida ||
                   fracc.SubdivisionLegal.Estatus == EstatusDeSubdivision.Donada ||
                   fracc.SubdivisionLegal.Estatus == EstatusDeSubdivision.Garantia ||
                   fracc.SubdivisionLegal.Estatus == EstatusDeSubdivision.Comprometida));
                
            });
        }

    }
}
