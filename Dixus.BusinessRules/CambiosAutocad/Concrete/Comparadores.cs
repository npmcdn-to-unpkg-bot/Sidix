using Dixus.BusinessRules.CambiosAutocad.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.CambiosAutocad.Concrete
{
    public class ComparadorDeFraccionesCompleto : IEqualityComparer<InfoComparableDeFraccion>
    {
        public bool Equals(InfoComparableDeFraccion x, InfoComparableDeFraccion y)
        {
            return (x.Nombre == y.Nombre &&
                x.UsoDeSueloId == y.UsoDeSueloId &&
                x.Geometria.SpatialEquals(y.Geometria));
        }
        public int GetHashCode(InfoComparableDeFraccion obj)
        {
            return obj.Nombre.GetHashCode();
        }
    }

    public class ComparadorDeVialidadesCompleto : IEqualityComparer<InfoComparableDeVialidad>
    {
        public bool Equals(InfoComparableDeVialidad x, InfoComparableDeVialidad y)
        {
            return (x.Nombre == y.Nombre &&
                x.Tramo == y.Tramo &&
                x.Geometria.SpatialEquals(y.Geometria));
        }

        public int GetHashCode(InfoComparableDeVialidad obj)
        {
            return obj.Nombre.GetHashCode();
        }
    }
}
