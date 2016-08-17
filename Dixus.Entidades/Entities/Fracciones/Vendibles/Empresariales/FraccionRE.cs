using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class FraccionRE : FraccionEmpresarial, IValidatableObject
    {
        public FraccionRE()
        {
            TipoDeSueloId = (int) TiposDeSuelo.ReservaEstrategica;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.ReservaEstrategica)
                yield return new ValidationResult("El tipo de suelo de una fracción de reserva estratégica tiene que ser " + (int)TiposDeSuelo.ReservaEstrategica, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }
    }
}