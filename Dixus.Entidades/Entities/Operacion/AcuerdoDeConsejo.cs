using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{

    [Table("AcuerdosDeConsejo")]
    public class AcuerdoDeConsejo : Entidad
    {
        [Key]
        public int AcuerdoDeConsejoId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }

        [ForeignKey("JuntaDeConsejo")]
        public int JuntaDeConsejoId { get; set; }
        public virtual JuntaDeConsejo JuntaDeConsejo { get; set; }
    }

   

}
