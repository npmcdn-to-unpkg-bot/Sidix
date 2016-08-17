using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    public class FraccionDON : FraccionNoVendibles, IValidatableObject
    {
        public FraccionDON()
        {
            TipoDeSueloId = (int)TiposDeSuelo.Donaciones;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.Donaciones)
                yield return new ValidationResult("El tipo de suelo de una fracción de donacion tiene que ser " + (int)TiposDeSuelo.Donaciones, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }

    }
}