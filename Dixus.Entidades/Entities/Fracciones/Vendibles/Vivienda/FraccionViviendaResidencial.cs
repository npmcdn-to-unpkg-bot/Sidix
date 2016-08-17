using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class FraccionViviendaResidencial : FraccionVivienda, IValidatableObject
    {
        public FraccionViviendaResidencial()
        {
            TipoDeSueloId = (int)TiposDeSuelo.ViviendaResidencial;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.ViviendaResidencial)
                yield return new ValidationResult("El tipo de suelo de una fracción de vivienda residencial tiene que ser " + (int)TiposDeSuelo.ViviendaResidencial, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }
    }
}