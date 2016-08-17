using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public class Opciones : IValidatableObject
    {
        public int OpcionesId { get; set; }
        public int NumeroDeEtapas { get; set; }

        // AUTOCAD
        /// <summary>
        /// Checar que la suma de superficies de fracciones y vialidades de lo mismo que el area total del proyecto, la cual debe ser especificada usando la propiedad "AreaTotalEsperada". Se puede aplicar un margen de error utilizando la propiedad "MargenDeError". Default es true
        /// </summary>
        public bool ValidarSuperficieTotal { get; set; }
        /// <summary>
        /// Area total del proyecto usada para validar que cambios al sistema tienen el area correcta. Default es 0;
        /// </summary>
        public double AreaTotalDelProyectoEnMetros { get; set; }
        /// <summary>
        /// Margen de error en metros cuadrados respecto al area total del proyecto que se la permite al usuario al momento de actualizar la informacion de planos. Default es 0;
        /// </summary>
        public double ToleranciaEnM2ParaProyecto { get; set; }

        /// <summary>
        /// Checar que todos los records de fracciones y vialidades en la base de datos sean poligonos usando la propiedad ".SpatialTypeName". Default es true
        /// </summary>
        public bool ValidarQueTodasLasGeometriasSeanPoligonos { get; set; }
        /// <summary>
        /// Checar que todos los records de fracciones y vialidades sean validos usando la propiedad ".IsValid". No se aplica la funcion "MakeValid()". Default es true
        /// </summary>
        public bool ValidarQuePoligonosSeanValidos { get; set; }
        /// <summary>
        /// Checar que ningun poligono en las tablas de fracciones y vialidades se sobrepongan a otro utilizando la función ".Intersects()". También ayuda a asegurar que ningun poligono se repita. Default es true
        /// </summary>
        public bool ValidarQuePoligonosNoSeSobrepongan { get; set; }
        /// <summary>
        /// Checar que todos los poligonos estén correctamente cerrados. Default es true
        /// </summary>
        public bool ValidarQuePoligonosEstenCerrados { get; set; }
        /// <summary>
        /// Tamaño maximo en metros cuadrados que puede tener una figura/geometria que representa una sobreposicion. Default es 0;
        /// </summary>
        public double TamañoMaximoDeSobreposiciones { get; set; }
        public bool ValidarQueFraccionesNoSeanInmodificables { get; set; }

        // Gastos Por Fraccionar
        public decimal ProyectoPlanMaestroPorM2 { get; set; }
        public decimal PresupuestoYUrbanizacionPorM2 { get; set; }
        public decimal ImpactoAmbientalPorM2 { get; set; }
        public decimal AutorizacionImpactoAmbientalPorM2 { get; set; }
        public decimal RasantesAguaPotableYDrenajePorM2 { get; set; }
        public decimal LicenciaUsoDeSueloPorM2 { get; set; }
        public decimal DeslindeDeTerrenoPorM2 { get; set; }
        public decimal EstudioTopograficoPorM2 { get; set; }
        public decimal EstudioInundabilidadPorM2 { get; set; }
        public decimal MecanicaDeSuelosPorM2 { get; set; }
        public decimal AutorizacionPorM2 { get; set; }
        public decimal PredialesPorM2 { get; set; }
        // Obras especiales
        public decimal KiloPorM2 { get; set; }
        public decimal ParquePorM2 { get; set; }
        public decimal ArborizacionPorM2 { get; set; }
        public decimal BardaPerimetralPorM2 { get; set; }
        public decimal BardaDecorativaPorM2 { get; set; }
        public decimal MurosDeContencionPorM2 { get; set; }
        //Urbanizacion
        public decimal UrbanizacionPorM2 { get; set; }

        //Proyectos de inversion
        public double? PorcentajedeTUPertenecienteATierra { get; set; }
        public double? PorcentajedeTUPertenecienteAGastosPorFraccionar { get; set; }
        public double? PorcentajedeTUPertenecienteAInfraestructura { get; set; }
        public double? PorcentajedeTUPertenecienteAObrasEspeciales { get; set; }
        public double? PorcentajedeTUPertenecienteAUrbanizacion { get; set; }
        public double? PorcentajedeTUPertenecienteAPostVenta { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            double totalPorcentajeDeTu = 0;
            totalPorcentajeDeTu += PorcentajedeTUPertenecienteAGastosPorFraccionar ?? 0;
            totalPorcentajeDeTu += PorcentajedeTUPertenecienteAInfraestructura ?? 0;
            totalPorcentajeDeTu += PorcentajedeTUPertenecienteAObrasEspeciales ?? 0;
            totalPorcentajeDeTu += PorcentajedeTUPertenecienteAPostVenta ?? 0;
            totalPorcentajeDeTu += PorcentajedeTUPertenecienteATierra ?? 0;
            totalPorcentajeDeTu += PorcentajedeTUPertenecienteAUrbanizacion ?? 0;
            if (totalPorcentajeDeTu != 1)
            {
                yield return new ValidationResult("La sumas de la distrubución de porcentajes para el cálculo del TU debe ser igual a 1"
                    , new string[] { "PorcentajedeTUPertenecienteAGastosPorFraccionar", "PorcentajedeTUPertenecienteAInfraestructura", "PorcentajedeTUPertenecienteAObrasEspeciales", "PorcentajedeTUPertenecienteAPostVenta", "PorcentajedeTUPertenecienteATierra", "PorcentajedeTUPertenecienteAUrbanizacion" });
            }
        }
    }
}
