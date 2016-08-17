using Dixus.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dixus.Entidades;

namespace Dixus.WebUI.Models
{
    public class AdminUsuariosViewModel
    {
        public IEnumerable<UsuariosConRol> usuarios { get; set; }

    }

    public class AdminOpcionesViewModel
    {
        public int OpcionesId { get { return 1; } }
        public int NumeroDeEtapas { get; set; }

        public double AreaTotalDelProyectoEnMetros { get; set; }
        public bool ValidarSuperficieTotal { get; set; }
        public double ToleranciaEnM2ParaProyecto { get; set; }
        public bool ValidarQueTodasLasGeometriasSeanPoligonos { get; set; }
        public bool ValidarQuePoligonosSeanValidos { get; set; }
        public bool ValidarQuePoligonosNoSeSobrepongan { get; set; }
        public bool ValidarQuePoligonosEstenCerrados { get; set; }
        public bool ValidarQueFraccionesNoSeanInmodificables { get; set; }

        public double TamañoMaximoDeSobreposiciones { get; set; }

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

        // Porcentajes de TU
        public double PorcentajedeTUPertenecienteATierra { get; set; }
        public double PorcentajedeTUPertenecienteAGastosPorFraccionar { get; set; }
        public double PorcentajedeTUPertenecienteAInfraestructura { get; set; }
        public double PorcentajedeTUPertenecienteAObrasEspeciales { get; set; }
        public double PorcentajedeTUPertenecienteAUrbanizacion { get; set; }
        public double PorcentajedeTUPertenecienteAPostVenta { get; set; }

    }

    public class UsuariosConRol
    {
        public string Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Puesto { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }

    public class AgregarUsuarioViewModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor introduce el nombre de la persona que deseas agregar")]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        public string Puesto { get; set; }

        public RolesDeUsuario Roles { get; set; }
    }

    public class RolesDeUsuario
    {
        public bool EsAdministrador { get; set; }
        public bool EsTecnico { get; set; }
        public bool EsLegal { get; set; }
        public bool EsVentas { get; set; }
    }

    public class ConcentradoOperacionViewModel
    {
        public IEnumerable<JuntaDeConsejo> Juntas { get; set; }
        public IEnumerable<AcuerdoDeConsejo> Acuerdos { get; set; }
        public IEnumerable<Tarea> Tareas { get; set; }
    }

}