using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class FraccionViviendaPopular : FraccionVivienda, IValidatableObject
    {
        public FraccionViviendaPopular()
        {
            TipoDeSueloId = (int)TiposDeSuelo.ViviendaPopular;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.ViviendaPopular)
                yield return new ValidationResult("El tipo de suelo de una fracción de vivienda popular tiene que ser " + (int)TiposDeSuelo.ViviendaPopular, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }
    }
}