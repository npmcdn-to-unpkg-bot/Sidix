using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class FraccionSE : FraccionEmpresarial, IValidatableObject
    {
        public FraccionSE()
        {
            TipoDeSueloId = (int)TiposDeSuelo.ServiciosEspeciales;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.ServiciosEspeciales)
                yield return new ValidationResult("El tipo de suelo de una fracción de servicios especiales tiene que ser " + (int)TiposDeSuelo.ServiciosEspeciales, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }
    }
}