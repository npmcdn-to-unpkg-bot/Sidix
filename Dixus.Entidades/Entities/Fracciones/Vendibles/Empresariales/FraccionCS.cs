using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class FraccionCS : FraccionEmpresarial, IValidatableObject
    {
        public FraccionCS()
        {
            TipoDeSueloId = (int)TiposDeSuelo.ComercioYServicios;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.ComercioYServicios)
                yield return new ValidationResult("El tipo de suelo de una fracción de comercio y servicios tiene que ser " + (int)TiposDeSuelo.ComercioYServicios, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }
    }
}