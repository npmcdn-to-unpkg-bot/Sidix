using System;

namespace Dixus.Entidades
{
    public class Entidad
    {
        public DateTime FechaCreada { get; set; }
        public DateTime UltimaModificacion { get; set; }
    }

    public class EntidadDescontinuable : Entidad
    {
        public bool Descontinuada { get; set; }
        public DateTime? FechaDescontinuada { get; set; }
       
    }
}
