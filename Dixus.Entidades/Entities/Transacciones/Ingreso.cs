using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    [Table("Ingresos")]
    public class Ingreso : Transaccion, IValidatableObject
    {
        public bool EsRenta { get; set; }
        public int? Mes { get; set; }
        public int? Año { get; set; }
        //public virtual ICollection<FraccionVendible> Fracciones { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if( EsRenta && !Mes.HasValue)
                yield return new ValidationResult("Debes especificar el mes al que pertenece este pago de renta",new string[] {"Mes"});
            if (EsRenta && !Año.HasValue)
                yield return new ValidationResult("Debes especificar el año al que pertenece este pago de renta", new string[] { "Año" });
        }
    }
}
