using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    [Table("EscriturasTraspaso"/*, Schema = "Legal"*/)]
    public class EscrituraDeTraspaso : Escritura, IValidatableObject
    {
        public DateTime FechaDeTraspaso { get; set; }
        public virtual ICollection<FraccionLegal> Subdivisiones { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FechaDeTraspaso > DateTime.Now)
            {
                yield return new ValidationResult("La fecha de traspaso de puede ser mayor a la fecha actual", new string[] { "FechaDeTraspaso" });
            }
        }
    }

}
