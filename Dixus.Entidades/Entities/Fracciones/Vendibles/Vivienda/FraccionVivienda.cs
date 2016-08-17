using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    //[Table("FraccionesVivienda")]
    public abstract class FraccionVivienda : FraccionVendible, IValidatableObject
    {
        private const double PorcentajeVendible = .60;

        //Datos Reales proporcionados por Desarrolladoras
        public int? ViviendasDesarrolladas { get; set; }
        public int? ViviendasEnProceso { get; set; }
        public int? ViviendasPorDesarrollar { get; set; }
        public int ViviendasTotales {
            get {
                int total = 0;
                if (ViviendasDesarrolladas.HasValue) total += ViviendasDesarrolladas.Value;
                if (ViviendasEnProceso.HasValue) total += ViviendasEnProceso.Value;
                if (ViviendasPorDesarrollar.HasValue) total += ViviendasPorDesarrollar.Value;
                return total;
            }
        }

        public override double MetrosVendibles { get { return MetrosCuadradosAprovechables * PorcentajeVendible; } }

        //Datos teoricos
        public double GetViviendasPronosticadas()
        {
            var temp = ((TipoDeSueloVivienda)TipoDeSuelo).ViviendaPorHectareaPromedio * HectareasAprovechables;
            //return (int)Math.Floor(temp);
            return temp;
        }
        public double GetHabitantesPronosticados()
        {
            var temp = ((TipoDeSueloVivienda)TipoDeSuelo).HabitantesPorViviendaPromedio * GetViviendasPronosticadas();
            //return (int)Math.Round(temp);
            return temp;
        }

        public double GetLpsMedio()
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
            return GetHabitantesPronosticados() * 250 / 86400;

        }
        public override double GetLpsMedioDiarioAgua()
        {
            return GetLpsMedio() * 1.4;
        }
        public double GetLpsMedioHorario()
        {
            return GetLpsMedioDiarioAgua() * 1.5;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if (!(TipoDeSuelo is TipoDeSueloVivienda))
            //    yield return new ValidationResult("El tipo de suelo de una fraccion de vivienda debe ser de vivienda también (no empresarial, ni fracciones que no se vendan)", new string[] { "TipoDeSueloId" });

            foreach (var valresult in base.Validate(validationContext))
            {
                yield return valresult;
            }

        }
    }
}