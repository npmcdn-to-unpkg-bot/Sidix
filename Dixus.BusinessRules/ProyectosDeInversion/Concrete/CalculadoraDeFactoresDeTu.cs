using Dixus.BusinessRules.ProyectosDeInversion.Entidades;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.ProyectosDeInversion
{
    public class CalculadoraDeFactoresDeTu : ICalculadoraDeFactoresDeTu
    {
        private Opciones _opc;
        public CalculadoraDeFactoresDeTu(Opciones opcionesParam)
        {
            _opc = opcionesParam;
        }

        public FactoresDeTu ObtenerFactoresDeTu()
        {
            FactoresDeTu factores = new FactoresDeTu()
            {
                ArborizacionKiloYParque = _opc.ArborizacionPorM2,
                Autorizacion = _opc.AutorizacionPorM2,
                AutorizacionImpactoAmbientalFederal = _opc.AutorizacionImpactoAmbientalPorM2,
                ImpactoAmbiental = _opc.ImpactoAmbientalPorM2,
                LicenciaUsoDelSuelo = _opc.LicenciaUsoDeSueloPorM2,
                MecanicaDeSuelos = _opc.MecanicaDeSuelosPorM2,
                BardaDecorativa = _opc.BardaDecorativaPorM2,
                BardaPerimetral = _opc.BardaPerimetralPorM2,
                DeslindeDelTerreno = _opc.DeslindeDeTerrenoPorM2,
                EstudioDeInundabilidad = _opc.EstudioInundabilidadPorM2,
                EstudioTopografico = _opc.EstudioTopograficoPorM2,
                Kilo = _opc.KiloPorM2,
                MurosDeContención = _opc.MurosDeContencionPorM2,
                ProyectoDeRasantesAguaPotableYDrenaje = _opc.RasantesAguaPotableYDrenajePorM2,
                PagoPresupuestoUrbanizacion = _opc.PresupuestoYUrbanizacionPorM2,
                Parque = _opc.ParquePorM2,
                Prediales = _opc.PredialesPorM2,
                ProyectoPlanMaestro = _opc.ProyectoPlanMaestroPorM2,
                Urbanizacion = _opc.UrbanizacionPorM2
            };
            return factores;
        }

    }
}
