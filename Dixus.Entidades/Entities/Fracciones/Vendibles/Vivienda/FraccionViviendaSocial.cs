using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class FraccionViviendaSocial : FraccionVivienda, IValidatableObject
    {
        public FraccionViviendaSocial()
        {
            TipoDeSueloId = (int)TiposDeSuelo.ViviendaSocial;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.ViviendaSocial)
                yield return new ValidationResult("El tipo de suelo de una fracción de vivienda social tiene que ser " + (int)TiposDeSuelo.ViviendaSocial, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }
    }
}