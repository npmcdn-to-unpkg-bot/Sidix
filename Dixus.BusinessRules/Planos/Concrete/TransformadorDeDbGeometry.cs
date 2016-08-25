using Dixus.BusinessRules.Planos.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.Planos.Concrete
{
    public class TransformadorDeGeometriaAGeoJson : ITransformadorDeGeometriaAGeoJson
    {
        public object[] ConvertirPoligonoEnCoordinadasGeoJson(DbGeometry geometria)
        {
            if (geometria.SpatialTypeName != "Polygon")
            {
                throw new ArgumentException("Para obtener un array de los vertices, la geometria debe ser un polígono. Por favor asegurese de está intentando transformar polígonos");
            }

            double[,] listaDeCoordenadas = new double[geometria.PointCount.Value, 2];

            for (int i = 1; i <= geometria.PointCount; i++)
            {
                var point = geometria.PointAt(i);
                var lat = point.XCoordinate.Value;
                var lng = point.YCoordinate.Value;
                listaDeCoordenadas[i - 1, 0] = lat;
                listaDeCoordenadas[i - 1, 1] = lng;
            }
            return new object[]
            {
                listaDeCoordenadas
            };
        }
    }
}
