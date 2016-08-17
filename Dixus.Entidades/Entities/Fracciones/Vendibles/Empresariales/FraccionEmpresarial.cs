using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    //[Table("Empresariales")]
    public abstract class FraccionEmpresarial : FraccionVendible, IValidatableObject
    {
        public double GetMetrosCuadradosParaDemanda()
        {
            //TODO: Fraccion debe de poder especificar su propio porcentaje para demanda
            return MetrosCuadradosAprovechables * ((TipoDeSueloEmpresarial)TipoDeSuelo).PorcentajeParaDemanda;
        }
        public override double GetLpsMedioDiarioAgua()
        {
            if (InversionesCalculadasDiferente && CalculosEspeciales != null)
            {
                if (CalculosEspeciales.NoOcupaAgua) return 0;
                if (CalculosEspeciales.NoUsaAguaStandard)
                {
                    if (CalculosEspeciales.FactorDeUsoAgua.HasValue) return CalculosEspeciales.FactorDeUsoAgua.Value * Hectareas;
                    else if (CalculosEspeciales.CantidadAgua.HasValue) return CalculosEspeciales.CantidadAgua.Value;
                }
            }
            return GetMetrosCuadradosParaDemanda() / 10000 * ((TipoDeSueloEmpresarial)TipoDeSuelo).LpsPorHectareaParaDemanda;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if ( !(TipoDeSuelo is TipoDeSueloEmpresarial) )
            //    yield return new ValidationResult("El tipo de suelo de una fraccion empresarial debe ser empresarial también (no vivienda, ni fracciones no vendibles)", new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }

        }
    }
}