using Dixus.BusinessRules;
using Dixus.BusinessRules.Planos.Entidades;
using Dixus.Entidades;
using Dixus.Entidades.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dixus.WebUI.Models
{
    public class RevisarCambiosAPlanosViewModel
    {
        public IEnumerable<Fraccion> FraccionesSidixQueNoTienenContraparte { get; set; }
        public IEnumerable<FeatureFraccion> FraccionesAutocadQueNoTienenContraparte { get; set; }
        public IEnumerable<Vialidad> VialidadesSidixQueNoTienenContraparte { get; set; }
        public IEnumerable<VialPoly> VialidadesAutocadQueNoTienenContraparte { get; set; }

        public IEnumerable<ModificacionAPropiedadesDeFraccion> ObtenerFraccionesQueNomasModificaronNombre;
        public IEnumerable<ModificacionAPropiedadesDeFraccion> ObtenerFraccionesQueNomasModificaronUsoDeSuelo;
        public IEnumerable<ModificacionAPropiedadesDeFraccion> ObtenerFraccionesQueModificaronNombreYUso;
        public IEnumerable<ModificacionAPropiedadesDeFraccion> ObtenerFraccionesQueSiguenIdenticas;

        public IEnumerable<ModificacionAPropiedadesDeVialidad> ObtenerVialidadesQueNomasModificaronNombre;
        public IEnumerable<ModificacionAPropiedadesDeVialidad> ObtenerVialidadesQueNomasModificaronTramo;
        public IEnumerable<ModificacionAPropiedadesDeVialidad> ObtenerVialidadesQueModificaronNombreYTramo;
        public IEnumerable<ModificacionAPropiedadesDeVialidad> ObtenerVialidadesQueSiguenIdenticas;
    }


    public class ErroresDeValidacionViewModel
    {
        public IEnumerable<GeometriaSobrepuesta> GeometriasSobrepuestas { get; set; }
        public PoligonosAutocadQueNoPasaronValidacion PoligonosInvalidos { get; set; }
        public PoligonosAutocadQueNoPasaronValidacion GeometriasQueNoSonPoligonos { get; set; }
        public PoligonosAutocadQueNoPasaronValidacion PoligonosNoCerrados { get; set; }
        public IEnumerable<Fraccion> FraccionesModificadasQueNoSeDebenModificar { get; set; }
        public bool SumaTotalEsValida { get; set; }
    }


}