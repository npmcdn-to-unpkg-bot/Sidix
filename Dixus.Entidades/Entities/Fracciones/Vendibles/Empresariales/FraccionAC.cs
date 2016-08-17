using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class FraccionAC : FraccionEmpresarial, IValidatableObject
    {
        public FraccionAC()
        {
            TipoDeSueloId = (int)TiposDeSuelo.AreaConservacion;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.AreaConservacion)
                yield return new ValidationResult("El tipo de suelo de una fracción de area de conservación tiene que ser " + (int)TiposDeSuelo.AreaConservacion, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }
    }
}