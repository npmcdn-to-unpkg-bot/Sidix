using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class InfoInversionesEspeciales : Entidad, IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue(true)]
        public bool SeExcluyeDeCobroDeInversiones { get; set; }

        public bool NoOcupaEnergia { get; set; }
        public bool NoUsaEnergiaStandard { get; set; }
        public double? FactorDeUsoEnergia { get; set; }
        public double? CantidadEnergia { get; set; }
        public bool NoSeLeCobraEnergia { get; set; }
        public bool NoPagaLoMismoEnEnergia { get; set; }
        public double? PrecioEnergia { get; set; }
        public bool HizoObrasEnergiaAparte { get; set; }

        public bool NoOcupaAgua { get; set; }
        public bool NoUsaAguaStandard { get; set; }
        public double? FactorDeUsoAgua { get; set; }
        public double? CantidadAgua { get; set; }
        public bool NoSeLeCobraAgua { get; set; }
        public bool NoPagaLoMismoEnAgua { get; set; }
        public double? PrecioEspecialAgua { get; set; }
        public bool HizoObrasAguaAparte { get; set; }

        public virtual ICollection<Fraccion> Fracciones { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Si Ocupa energia
            if (!NoOcupaEnergia)
            {
                if (NoUsaEnergiaStandard)
                { //Si ocupa cantidad especial de energia tiene que especificar o CantidadEnergia o FactorDeUsoEnergia, no las dos, ni ninguna
                    if ((FactorDeUsoEnergia == null && CantidadEnergia == null) ||
                        (FactorDeUsoEnergia.HasValue && CantidadEnergia.HasValue))
                    {
                        yield return new ValidationResult(
                                "Si la fracción cuenta con cálculos de uso de energia especiales y SÍ usa energía, debes especificar ya sea: 1.Un indice de uso especial de uso de MVAs, ó 2. Una cantidad fija de MVAs (solo uno de los dos)", new string[] { "NoUsaEnergiaStandard" });
                    }
                }
                else {
                    //Si no ocupa cantidad especial, no puede tener ni CantidadEnergia ni FactorDeUsoEnergia
                    if (FactorDeUsoEnergia.HasValue || CantidadEnergia.HasValue)
                    {
                        yield return new ValidationResult(
                                "Si la fraccion no ocupa una cantidad especial de energía, no puedes especificar ni: 1.Un indice de uso especial de uso de MVAs, ni 2. Una cantidad fija de MVAs", new string[] { "NoUsaEnergiaStandard" });
                    }
                }

                //Si se le cobra
                if (!NoSeLeCobraEnergia)
                {
                    //Si ocupa precio especial
                    if (NoPagaLoMismoEnEnergia)
                    {
                        if (PrecioEnergia == null)
                            yield return new ValidationResult("Debes especificar el precio al que se le vende el MVA de energia");
                    }
                }
            }
            //No ocupa energia
            else
            {

            }
        }
    }
}
