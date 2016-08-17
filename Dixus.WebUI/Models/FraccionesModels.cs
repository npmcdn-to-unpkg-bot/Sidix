using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using Dixus.Entidades;
using Dixus.BusinessRules.ProyectosDeInversion.Entidades;
using Dixus.BusinessRules;
using Dixus.Entidades.Gis;

namespace Dixus.WebUI.Models
{
    public class FraccionNombreViewModel
    {
        public int FraccionId { get; set; }
        [Required(ErrorMessage = "Por favor especifica un nombre para la fracción")]
        public virtual string Nombre { get; set; }
    }

    public class FraccionInfoBasicaViewModel : FraccionNombreViewModel
    {
        [Required(ErrorMessage = "Se ocupa tipo de suelo")]
        public int TipoDeSueloId { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Los metros cuadrados tienen que ser mayores a 0.01")]
        public double MetrosCuadrados { get; set; }

        public int? Etapa { get; set; }
        [Range(minimum: 0, maximum: 1, ErrorMessage = "Factor topografico debe ser entre 0-100%")]
        [DisplayFormat(DataFormatString = "{0:##.##%}", ApplyFormatInEditMode = true)]
        public double? FactorTopografico { get; set; }
    }

    public class FraccionInfoGeneralViewModel : FraccionInfoBasicaViewModel
    {
        //Vendibles
        [Display(Name = "Está vendida")]
        public bool Vendida { get; set; }
        public int? AñoVenta { get; set; }
        public int? ClienteId { get; set; }

        //Comercial
        public int? TipoDeComercioId { get; set; }

        //Industrial
        public string ProductoProducido { get; set; }

        //Vivienda
        public int? ViviendasDesarrolladas { get; set; }
        public int? ViviendasEnProceso { get; set; }
        public int? ViviendasPorDesarrollar { get; set; }

        //Vialidades
        public double? Distancia { get; set; }
        public double? AnchoDelCarril { get; set; }
        public int? NumeroDeCarriles { get; set; }
    }

    public class CrearFraccionViewModel: FraccionInfoGeneralViewModel, IValidatableObject
    {
        public bool InversionesCalculadasDiferente { get; set; }

        public bool NoOcupaEnergia { get; set; }
        public bool NoUsaEnergiaStandard { get; set; }
        public double? FactorDeUsoEnergia { get; set; }
        public double? CantidadEnergia { get; set; }
        public bool NoSeLeCobraEnergia { get; set; }
        public bool NoPagaLoMismoEnEnergia { get; set; }
        public double? PrecioEnergia { get; set; }

        public bool NoOcupaAgua { get; set; }
        public bool NoUsaAguaStandard { get; set; }
        public double? FactorDeUsoAgua { get; set; }
        public double? CantidadAgua { get; set; }
        public bool NoSeLeCobraAgua { get; set; }
        public bool NoPagaLoMismoEnAgua { get; set; }
        public double? PrecioEspecialAgua { get; set; }

        public bool SeExcluyeDeCobroDeInversiones { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Vendida && !ClienteId.HasValue)
                yield return new ValidationResult("Una fraccion no puede ser marcada como vendida sin contar con un cliente", new string[] { "ClienteId" });

            if (Vendida && !AñoVenta.HasValue)
                yield return new ValidationResult("El año de venta debe ser ingresado si la fraccion ya fue vendida", new string[] { "AñoVenta" });

            if (Vendida && AñoVenta.HasValue && AñoVenta.Value > DateTime.Now.Year)
                yield return new ValidationResult("El año no puede ser mayor al año actual si la fracción ya fue vendida", new string[] { "AñoVenta" });

            if (InversionesCalculadasDiferente)
            {
                //Si Ocupa energia
                if (!NoOcupaEnergia) {
                    //Si ocupa cantidad especial
                    if (NoUsaEnergiaStandard) {
                        if ((FactorDeUsoEnergia == null && CantidadEnergia == null) ||
                            (FactorDeUsoEnergia.HasValue && CantidadEnergia.HasValue)) {
                            yield return new ValidationResult(
                                    "Si la fracción cuenta con cálculos de uso de energia especiales y SÍ usa energía, debes especificar ya sea: 1.Un indice de uso especial de uso de MVAs, ó 2. Una cantidad fija de MVAs (solo uno de los dos)");
                        }
                    }
                    //No ocupa cantidad especial
                    else{
                        if (FactorDeUsoEnergia.HasValue || CantidadEnergia.HasValue) {
                            yield return new ValidationResult(
                                    "Si la fraccion no ocupa una cantidad especial de energía, no debes especificar: 1.Un indice de uso especial de uso de MVAs, ni 2. Una cantidad fija de MVAs");
                        }
                    }

                    //Si se le cobra
                    if (!NoSeLeCobraEnergia){
                        //Si ocupa precio especial
                        if (NoPagaLoMismoEnEnergia){
                            if (PrecioEnergia == null)
                                yield return new ValidationResult("Debes especificar el precio al que se le vende el MVA de energia");
                        }
                    }
                }
                //No ocupa energia
                else{

                }
            }
        }
    }

    public class FraccionCompletaViewModel : FraccionInfoGeneralViewModel
    {
        public double MvasRequeridos { get; set; }
        public double LpsRequeridos { get; set; }
        public double LpsSaneamientoRequeridos { get; set; }

        public string NombreDeTipoDeSuelo { get; set; }
        public string ColorDeTipoDeSuelo { get; set; }

        public string NombreDeCliente { get; set; }
    }

    public class TablaFraccionesViewModel
    {
        public bool SonPurasVendibles { get { return this.FraccionesVendibles.Count() == Fracciones.Count(); } }
        public bool SonPurasVivienda { get { return Fracciones.OfType<FraccionVivienda>().Count() == Fracciones.Count(); } }
        //public bool SonPurasVialidades { get { return Fracciones.OfType<FraccionVIAL>().Count() == Fracciones.Count(); } }
        public bool SonPurasEmpresariales { get { return Fracciones.OfType<FraccionEmpresarial>().Count() == Fracciones.Count(); } }

        public bool ExcluirInfoFinanciera { get; set; }
        public bool ExcluirInfoUsoDeRecursos { get; set; }
        public bool ExcluirInfoCostoDeRecursos { get; set; }

        public IEnumerable<Fraccion> Fracciones { get; set; }
        public IEnumerable<FraccionVendible> FraccionesVendibles { get { return this.Fracciones.OfType<FraccionVendible>(); } }
        public IEnumerable<FraccionNoVendibles> FraccionesNoVendibles { get { return this.Fracciones.OfType<FraccionNoVendibles>(); } }
        public IEnumerable<FraccionVivienda> FraccionesVivienda { get { return this.Fracciones.OfType<FraccionVivienda>(); } }

    }

    public class VenderFraccionViewModel
    {
        public FraccionNombreViewModel Fraccion { get; set; }
        public int ClienteId { get; set; }
    }

    public class CambiosHechosEnAutocadViewModel
    {
       
    }
    
}
