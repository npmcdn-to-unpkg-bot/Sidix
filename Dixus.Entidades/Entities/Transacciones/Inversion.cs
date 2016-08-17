using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    [Table("Inversiones")]
    public class Inversion : Transaccion/*, IValidatableObject*/
    {
        //public bool EsHechaPorClientes { get; set; }
        //public int? FraccionId { get; set; }

        //public virtual Fraccion Fraccion { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (EsHechaPorClientes && !FraccionId.HasValue)
        //        yield return new ValidationResult("Inversiones hechas por clientes deben especificar la fraccion a la que pertenecen", new string[] { "EsHechaPorClientes" });
        //    if (!EsHechaPorClientes && FraccionId.HasValue)
        //        yield return new ValidationResult("Inversiones no hechas por clientes no pueden tener una fraccion a la que pertenecen", new string[] { "EsHechaPorClientes"});
        //}
    }
}