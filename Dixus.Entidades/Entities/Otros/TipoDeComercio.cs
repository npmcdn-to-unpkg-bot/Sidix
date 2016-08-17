using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    [Table("TiposDeComercio")]
    public class TipoDeComercio : Entidad
    {
        public int TipoDeComercioId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<FraccionCOM> FraccionesComerciales { get; set; }

    }
}
