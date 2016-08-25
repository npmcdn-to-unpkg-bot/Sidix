using Dixus.Entidades;
using Dixus.Entidades.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.Planos.Entidades
{
    public class ResumenDeCambiosAutocad
    {
        
        public IEnumerable<Fraccion> FraccionesSidixQueNoTienenContraparte { get; set; }
        public IEnumerable<FeatureFraccion> FraccionesAutocadQueNoTienenContraparte { get; set; }
        public IEnumerable<Vialidad> VialidadesSidixQueNoTienenContraparte { get; set; }
        public IEnumerable<VialPoly> VialidadesAutocadQueNoTienenContraparte { get; set; }

        public IEnumerable<ModificacionAPropiedadesDeFraccion> FraccionesSinModificacionAforma { get; set; }
        public IEnumerable<ModificacionAPropiedadesDeVialidad> VialidadesSinModificacionAforma { get; set; }
        
        public IEnumerable<ModificacionAPropiedadesDeFraccion> ObtenerFraccionesQueNomasModificaronNombre()
        {
            return FraccionesSinModificacionAforma.Where(x => x.CambioDeNombre == true && x.CambioDeUsoDeSuelo == false);
        }
        public IEnumerable<ModificacionAPropiedadesDeFraccion> ObtenerFraccionesQueNomasModificaronUsoDeSuelo()
        {
            return FraccionesSinModificacionAforma.Where(x => x.CambioDeNombre == false && x.CambioDeUsoDeSuelo == true);
        }
        public IEnumerable<ModificacionAPropiedadesDeFraccion> ObtenerFraccionesQueModificaronNombreYUso()
        {
            return FraccionesSinModificacionAforma.Where(x => x.CambioDeNombre == true && x.CambioDeUsoDeSuelo == true);
        }
        public IEnumerable<ModificacionAPropiedadesDeFraccion> ObtenerFraccionesQueSiguenIdenticas()
        {
            return FraccionesSinModificacionAforma.Where(x => x.CambioDeNombre == false && x.CambioDeUsoDeSuelo == false);
        }

        public IEnumerable<ModificacionAPropiedadesDeVialidad> ObtenerVialidadesQueNomasModificaronNombre()
        {
            return VialidadesSinModificacionAforma.Where(x => x.CambioDeNombre == true && x.CambioDeTramo == false);
        }
        public IEnumerable<ModificacionAPropiedadesDeVialidad> ObtenerVialidadesQueNomasModificaronTramo()
        {
            return VialidadesSinModificacionAforma.Where(x => x.CambioDeNombre == false && x.CambioDeTramo == true);
        }
        public IEnumerable<ModificacionAPropiedadesDeVialidad> ObtenerVialidadesQueModificaronNombreYTramo()
        {
            return VialidadesSinModificacionAforma.Where(x => x.CambioDeNombre == true && x.CambioDeTramo == true);
        }
        public IEnumerable<ModificacionAPropiedadesDeVialidad> ObtenerVialidadesQueSiguenIdenticas()
        {
            return VialidadesSinModificacionAforma.Where(x => x.CambioDeNombre == false && x.CambioDeTramo == false);
        }
    }

   

    
}
