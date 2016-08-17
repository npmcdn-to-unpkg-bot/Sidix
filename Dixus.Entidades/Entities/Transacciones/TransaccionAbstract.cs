using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    public abstract class Transaccion : Entidad
    {
        [Key]
        public int TransaccionID { get; set; }

        [Required]
        public string Concepto { get; set; }

        [Display(Name = "Fecha")]
        public DateTime FechaDeTransaccion { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Monto { get; set; }


    }   
}
