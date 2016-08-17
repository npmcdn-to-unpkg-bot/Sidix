using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.ProyectosDeInversion.Entidades
{
    public class TuMacronanzanaYDesarrollador
    {

        public TuMacronanzanaYDesarrollador(TuIndividual tudesarrollador, TuIndividual tumacromanzana)
        {
            TuDesarrollador = tudesarrollador;
            TuMacromanzana = tumacromanzana;
        }

        public TuIndividual TuDesarrollador { get; set; }
        public TuIndividual TuMacromanzana { get; set; }
        public TuIndividual TuTotal
        {
            get
            {
                return new TuIndividual()
                {
                    AdquisicionDeTierra = TuDesarrollador.AdquisicionDeTierra + TuMacromanzana.AdquisicionDeTierra,
                    GastosDeAdquisicion = TuDesarrollador.GastosDeAdquisicion + TuMacromanzana.GastosDeAdquisicion,
                    GastosNotariales = TuDesarrollador.GastosNotariales + TuMacromanzana.GastosNotariales,

                    ProyectoPlanMaestro = TuDesarrollador.ProyectoPlanMaestro + TuMacromanzana.ProyectoPlanMaestro,
                    PresupuestoYUrbanizacion = TuDesarrollador.PresupuestoYUrbanizacion + TuMacromanzana.PresupuestoYUrbanizacion,
                    ImpactoAmbiental = TuDesarrollador.ImpactoAmbiental + TuMacromanzana.ImpactoAmbiental,
                    AutorizacionImpactoAmbiental = TuDesarrollador.AutorizacionImpactoAmbiental + TuMacromanzana.AutorizacionImpactoAmbiental,
                    RasantesAguaPotableYDrenaje = TuDesarrollador.RasantesAguaPotableYDrenaje + TuMacromanzana.RasantesAguaPotableYDrenaje,
                    LicenciaUsoDeSuelo = TuDesarrollador.LicenciaUsoDeSuelo + TuMacromanzana.LicenciaUsoDeSuelo,
                    DeslindeDeTerreno = TuDesarrollador.DeslindeDeTerreno + TuMacromanzana.DeslindeDeTerreno,
                    EstudioTopografico = TuDesarrollador.EstudioTopografico + TuMacromanzana.EstudioTopografico,
                    EstudioInundabilidad = TuDesarrollador.EstudioInundabilidad + TuMacromanzana.EstudioInundabilidad,
                    MecanicaDeSuelos = TuDesarrollador.MecanicaDeSuelos + TuMacromanzana.MecanicaDeSuelos,
                    Autorizacion = TuDesarrollador.Autorizacion + TuMacromanzana.Autorizacion,
                    Prediales = TuDesarrollador.Prediales + TuMacromanzana.Prediales,
                    DerechosConexionAguaYDrenaje = TuDesarrollador.DerechosConexionAguaYDrenaje + TuMacromanzana.DerechosConexionAguaYDrenaje,
                    DerechosCFE = TuDesarrollador.DerechosCFE + TuMacromanzana.DerechosCFE,

                    EnergiaElectrica = TuDesarrollador.EnergiaElectrica + TuMacromanzana.EnergiaElectrica,
                    AguaPotable = TuDesarrollador.AguaPotable + TuMacromanzana.AguaPotable,
                    Saneamiento = TuDesarrollador.Saneamiento + TuMacromanzana.Saneamiento,
                    Vialidades = TuDesarrollador.Vialidades + TuMacromanzana.Vialidades,
                    ObrasEspeciales = TuDesarrollador.ObrasEspeciales + TuMacromanzana.ObrasEspeciales,
                    RedDigital = TuDesarrollador.RedDigital + TuMacromanzana.RedDigital,
                    GasNatural = TuDesarrollador.GasNatural + TuMacromanzana.GasNatural,
                    MovimientoDeTierra = TuDesarrollador.MovimientoDeTierra + TuMacromanzana.MovimientoDeTierra,
                    CostosIndirectos = TuDesarrollador.CostosIndirectos + TuMacromanzana.CostosIndirectos,

                    Kilo = TuDesarrollador.Kilo + TuMacromanzana.Kilo,
                    Parque = TuDesarrollador.Parque + TuMacromanzana.Parque,
                    ArborizacionKiloYParque = TuDesarrollador.ArborizacionKiloYParque + TuMacromanzana.ArborizacionKiloYParque,
                    BardaPerimetral = TuDesarrollador.BardaPerimetral + TuMacromanzana.BardaPerimetral,
                    BardaDecorativa = TuDesarrollador.BardaDecorativa + TuMacromanzana.BardaDecorativa,
                    MurosDeContencion = TuDesarrollador.MurosDeContencion + TuMacromanzana.MurosDeContencion,

                    Urbanizacion = TuDesarrollador.Urbanizacion + TuMacromanzana.Urbanizacion,

                    Vigilancia = TuDesarrollador.Vigilancia + TuMacromanzana.Vigilancia,
                    Mantenimiento = TuDesarrollador.Mantenimiento + TuMacromanzana.Mantenimiento
                    
                };
            }

        }

    }
}
