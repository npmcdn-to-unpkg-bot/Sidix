using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Dixus.Entidades
{
    [Table("Fracciones")]
    public abstract class Fraccion : EntidadDescontinuable, IValidatableObject
    {
        public int FraccionId { get; set; }

        [Required]
        public string Nombre { get; set; }
        public double MetrosCuadrados { get; set; }
        public double Hectareas => MetrosCuadrados / 10000;
        public double MetrosCuadradosAprovechables => FactorTopografico.HasValue ? MetrosCuadrados * (1 - FactorTopografico.Value) : MetrosCuadrados;
        public double HectareasAprovechables => MetrosCuadradosAprovechables / 10000;
        public virtual double MetrosVendibles => MetrosCuadradosAprovechables; 
        public int? Etapa { get; set; }
        [Range(minimum: 0, maximum: 1, ErrorMessage = "Factor topografico debe ser entre 0-100%")]
        [DisplayFormat(DataFormatString = "{0:##.##%}", ApplyFormatInEditMode = true, NullDisplayText = "-")]
        public double? FactorTopografico { get; set; }
        public bool InversionesCalculadasDiferente { get; set; }
        public double? TuDeReferencia { get; set; }
        public string Observaciones { get; set; }
        [Required]
        public DbGeometry Geometria { get; set; }

        public string Manzana { get; set; }
        public string Lote { get; set; }
        public string Zona { get; set; }

        public virtual double GetMvaRequeridos()
        {
            if (InversionesCalculadasDiferente && CalculosEspeciales != null)
            {
                if (CalculosEspeciales.NoOcupaEnergia) return 0;
                if (CalculosEspeciales.NoUsaEnergiaStandard)
                {
                    if (CalculosEspeciales.FactorDeUsoEnergia.HasValue) return CalculosEspeciales.FactorDeUsoEnergia.Value * Hectareas;
                    else if (CalculosEspeciales.CantidadEnergia.HasValue) return CalculosEspeciales.CantidadEnergia.Value;
                }
            }
            return TipoDeSuelo.MvaPorHectarea * Hectareas;
        }
        public abstract double GetLpsMedioDiarioAgua();
        public virtual double GetLpsMedioDiarioSaneamiento()
        {
            return GetLpsMedioDiarioAgua() * 0.75;
        }
        public EstatusDeSubdivision ObtenerEstatus()
        {
            if (SubdivisionLegal == null) return EstatusDeSubdivision.Libre;
            else
            {
                return SubdivisionLegal.Estatus;
            }
        }

        [ForeignKey("TipoDeSuelo")]
        public int TipoDeSueloId { get; set; }
        public virtual TipoDeSuelo TipoDeSuelo { get; set; }

        [ForeignKey("CalculosEspeciales")]
        public int? CalculosEspecialesId { get; set; }
        public virtual InfoInversionesEspeciales CalculosEspeciales { get; set; }
        
        [ForeignKey("SubdivisionLegal")]
        public int? FraccionLegalId { get; set; }
        public virtual FraccionLegal SubdivisionLegal { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SubdivisionLegal != null && SubdivisionLegal.Superficie != MetrosCuadrados)
                yield return new ValidationResult("Si la fracción está relacionada a una subdivision legal, estas deben de tener la misma superficie");

            if (InversionesCalculadasDiferente && CalculosEspecialesId == null)
                yield return new ValidationResult("La fraccion no puede tener inversiones calculadas diferentes, si no tiene informacion sobre los calculos especiales");
        }
        


    }

    //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]

}   