using System;

namespace Dixus.Entidades
{
    public class Entidad
    {
        public DateTime FechaCreada { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public DateTime? FechaDescontinuada { get; set; }
        public bool Descontinuada { get; set; }
    }
}
