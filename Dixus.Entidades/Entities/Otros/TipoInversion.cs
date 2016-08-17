using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    [Table("TiposDeInversion")]
    public class TipoInversion : Entidad
    {
        public int TipoInversionId { get; set; }
        public string Nombre { get; set; }
    }
}