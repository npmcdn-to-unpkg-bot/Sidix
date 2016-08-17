using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class FraccionEU : FraccionNoVendibles, IValidatableObject
    {
        public FraccionEU()
        {
            TipoDeSueloId = (int)TiposDeSuelo.EquipamentoUrbano;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.EquipamentoUrbano)
                yield return new ValidationResult("El tipo de suelo de una fracción de equipamiento urbano tiene que ser " + (int)TiposDeSuelo.EquipamentoUrbano, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }
    }
}