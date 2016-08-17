using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class FraccionPAT : FraccionEmpresarial, IValidatableObject
    {
        public FraccionPAT()
        {
            TipoDeSueloId = (int)TiposDeSuelo.ParqueAltaTecnologia;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.ParqueAltaTecnologia)
                yield return new ValidationResult("El tipo de suelo de una fracci�n de parque de alta tecnolog�a tiene que ser " + (int)TiposDeSuelo.ParqueAltaTecnologia, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }
    }
}