using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class FraccionIN : FraccionEmpresarial, IValidatableObject
    {
        public FraccionIN()
        {
            TipoDeSueloId = (int)TiposDeSuelo.Industrial;
        }

        public string ProductoProducido { get; set; }


        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.Industrial)
                yield return new ValidationResult("El tipo de suelo de una fracción industrial tiene que ser " + (int)TiposDeSuelo.Industrial, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }
    }
}