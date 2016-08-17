using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    public class FraccionCOM : FraccionEmpresarial
    {
        public FraccionCOM()
        {
            TipoDeSueloId = (int)TiposDeSuelo.Comercial;
        }

        [ForeignKey("TipoDeComercio")]
        public int? TipoDeComercioId { get; set; }
        public TipoDeComercio TipoDeComercio { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDeSueloId != (int)TiposDeSuelo.Comercial)
                yield return new ValidationResult("El tipo de suelo de una fracción comercial tiene que ser " + (int)TiposDeSuelo.Comercial, new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }
        }

    }

}
