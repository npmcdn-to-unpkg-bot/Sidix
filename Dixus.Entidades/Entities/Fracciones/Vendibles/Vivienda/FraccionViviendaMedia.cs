using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class FraccionViviendaMedia : FraccionVivienda, IValidatableObject
    {
        public FraccionViviendaMedia()
        {
            TipoDeSueloId = (int)TiposDeSuelo.ViviendaMedia;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.ViviendaMedia)
                yield return new ValidationResult("El tipo de suelo de una fracción de vivienda media tiene que ser " + (int)TiposDeSuelo.ViviendaMedia, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }
    }
}