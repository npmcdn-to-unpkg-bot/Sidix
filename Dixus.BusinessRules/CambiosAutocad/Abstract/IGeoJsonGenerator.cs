using Dixus.BusinessRules.CambiosAutocad.Concrete;
using Dixus.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.CambiosAutocad.Abstract
{
    public interface IGeoJsonGenerator
    {
        object[] TransformarFraccionesAGeoJson(IEnumerable<Fraccion> fracciones);
        object[] TransformarFraccionesAGeoJson(IEnumerable<Fraccion> fracciones, ITransformadorDeGeometriaAGeoJson transformador);
        object[] TransformarVialidadesAGeoJson(IEnumerable<Vialidad> vialidades);
        object[] TransformarVialidadesAGeoJson(IEnumerable<Vialidad> vialidades, ITransformadorDeGeometriaAGeoJson transformador);
    }

    public class GeoJsonGenerator : IGeoJsonGenerator
    {
        public object[] TransformarFraccionesAGeoJson(IEnumerable<Fraccion> fracciones)
        {
            ITransformadorDeGeometriaAGeoJson transformador = new TransformadorDeGeometriaAGeoJson();
            return TransformarFraccionesAGeoJson(fracciones, transformador);
        }
        public object[] TransformarFraccionesAGeoJson(IEnumerable<Fraccion> fracciones, ITransformadorDeGeometriaAGeoJson transformador)
        {
            List<object> features = new List<object>();
            foreach (var fracc in fracciones)
            {
                features.Add(new
                {
                    type = "Feature",
                    properties = new
                    {
                        Nombre = fracc.Nombre,
                        Id = fracc.FraccionId,
                        Area = fracc.MetrosCuadrados,
                        UsoDeSuelo = fracc.TipoDeSuelo.Nombre,
                        UsoDeSueloId = fracc.TipoDeSueloId,
                        Color = fracc.TipoDeSuelo.Color,
                        Estatus = fracc.ObtenerEstatus().ToString(),
                        Manzana = String.IsNullOrEmpty(fracc.Manzana) ? "-" : fracc.Manzana,
                        Lote = fracc.Lote ?? "-",
                        Observaciones = fracc.Observaciones
                    },
                    geometry = new
                    {
                        type = fracc.Geometria.SpatialTypeName,
                        coordinates = transformador.ConvertirPoligonoEnCoordinadasGeoJson(fracc.Geometria)
                    }
                });
            }
            return features.ToArray();
        }
        public object[] TransformarVialidadesAGeoJson(IEnumerable<Vialidad> vialidades)
        {
            ITransformadorDeGeometriaAGeoJson transformador = new TransformadorDeGeometriaAGeoJson();
            return TransformarVialidadesAGeoJson(vialidades, transformador);
        }
        public object[] TransformarVialidadesAGeoJson(IEnumerable<Vialidad> vialidades, ITransformadorDeGeometriaAGeoJson transformador)
        {
            List<object> features = new List<object>();
            foreach (var vial in vialidades)
            {
                features.Add(new
                {
                    type = "Feature",
                    properties = new
                    {
                        Nombre = vial.Nombre,
                        Id = vial.VialidadId,
                        Area = vial.MetrosCuadrados,
                        Tramo = vial.Tramo,
                        NumeroDeCarriles = vial.NumeroDeCarriles,
                        Longitud = vial.Longitud
                    },
                    geometry = new
                    {
                        type = vial.Geometria.SpatialTypeName,
                        coordinates = transformador.ConvertirPoligonoEnCoordinadasGeoJson(vial.Geometria)
                    }
                });
            }
            return features.ToArray();
        }
    }
}
