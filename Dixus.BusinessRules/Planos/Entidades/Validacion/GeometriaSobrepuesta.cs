namespace Dixus.BusinessRules
{
    using Planos.Entidades;
    using System.Data.Entity.Spatial;

    public class GeometriaSobrepuesta
    {
        public DbGeometry Geom { get; set; }
        public InfoComparableDePoligono InfoPoligono1 { get; set; }
        public InfoComparableDePoligono InfoPoligono2 { get; set; }
    }
}
