using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.CambiosAutocad.Entidades
{
    public class InfoComparableDePoligono
    {
        public DbGeometry Geometria { get; set; }
        public string Nombre { get; set; }
        public int Id { get; set; }
    }
    
    public class InfoComparableDeFraccion : InfoComparableDePoligono
    {
        public int UsoDeSueloId { get; set; }
    }

    public class InfoComparableDeVialidad : InfoComparableDePoligono
    {
        public string Tramo { get; set; }
    }
    
}
