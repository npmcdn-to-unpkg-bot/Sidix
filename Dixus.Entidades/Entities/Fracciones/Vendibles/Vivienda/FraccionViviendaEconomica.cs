using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class FraccionViviendaEconomica : FraccionVivienda, IValidatableObject
    {
        public FraccionViviendaEconomica()
        {
            TipoDeSueloId = (int)TiposDeSuelo.ViviendaEconomica;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.ViviendaEconomica)
                yield return new ValidationResult("El tipo de suelo de una fracción de vivienda económica tiene que ser " + (int)TiposDeSuelo.ViviendaEconomica, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }
    }
}