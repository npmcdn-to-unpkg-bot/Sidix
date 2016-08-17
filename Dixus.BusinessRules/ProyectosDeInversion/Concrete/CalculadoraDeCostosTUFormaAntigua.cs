using System;
using System.Linq;
using Dixus.BusinessRules.Inversiones;
using Dixus.BusinessRules.ProyectosDeInversion.Entidades;
using Dixus.Entidades;
using Dixus.BusinessRules.Inversiones.Entidades;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.ProyectosDeInversion
{
    public class CalculadoraDeCostosTUFormaAntigua : ICalculadoraDeCostosTU
    {
        public ICalculadoraDeCobroPorInfraestructura CalcCobrosPorInfraestructura;
        public ICalculadoraDeFactoresDeTu CalcFactoresDeTu;

        public CalculadoraDeCostosTUFormaAntigua(ICalculadoraDeCobroPorInfraestructura calcInfraestructura, ICalculadoraDeFactoresDeTu calcFactores)
        {
            CalcCobrosPorInfraestructura = calcInfraestructura;
            CalcFactoresDeTu = calcFactores;
        }

        public async Task<TuMacronanzanaYDesarrollador> CalcularTuDeFraccion(FraccionVendible _fracc)
        {
            TuIndividual TuDesarrollador = ObtenerTuDelDesarrollador(_fracc, CalcFactoresDeTu.ObtenerFactoresDeTu());
            TuIndividual TuMacromanzana = ObtenerTuDeMacromanzana(_fracc, await CalcCobrosPorInfraestructura.CalcularCobroDeInfraestructuraAFraccion(_fracc));
            return new TuMacronanzanaYDesarrollador(TuDesarrollador, TuMacromanzana);
        }

        private TuIndividual ObtenerTuDeMacromanzana(FraccionVendible fracc, CobrosPorInversiones cantidadesCargadasAFraccion)
        {
            TuIndividual TuMacromanzana = new TuIndividual() 
            {
                AdquisicionDeTierra = (decimal)(fracc.MetrosCuadrados * 1.8443),
                GastosNotariales = (decimal)(fracc.MetrosCuadrados * 1.8443 * 0.04),

                EnergiaElectrica = cantidadesCargadasAFraccion.Mvas,
                AguaPotable = cantidadesCargadasAFraccion.Lps,
                Saneamiento = cantidadesCargadasAFraccion.LpsSaneamiento,
                Vialidades = cantidadesCargadasAFraccion.Vialidades,
                ObrasEspeciales = cantidadesCargadasAFraccion.OtrasInversiones,
                RedDigital = cantidadesCargadasAFraccion.RedDigital,
                GasNatural = cantidadesCargadasAFraccion.GasNatural,
                MovimientoDeTierra = cantidadesCargadasAFraccion.MovimientoDeTierra,
                CostosIndirectos = cantidadesCargadasAFraccion.CostosIndirectos,
            };

            return TuMacromanzana;
        }

        private TuIndividual ObtenerTuDelDesarrollador(FraccionVendible fracc, FactoresDeTu factores)
        {
            // Calcular el TU inicial (temporal), basado en los factores, al que despues se le añadirán 2 datos más
            decimal superficie = (decimal)fracc.MetrosCuadradosAprovechables;
            TuIndividual TuDesarrollador = new TuIndividual()
            {
                ProyectoPlanMaestro = factores.ProyectoPlanMaestro * superficie,
                PresupuestoYUrbanizacion = factores.PagoPresupuestoUrbanizacion * superficie,
                ImpactoAmbiental = factores.ImpactoAmbiental * superficie,
                AutorizacionImpactoAmbiental = factores.AutorizacionImpactoAmbientalFederal * superficie,
                RasantesAguaPotableYDrenaje = factores.ProyectoDeRasantesAguaPotableYDrenaje * superficie,
                LicenciaUsoDeSuelo = factores.LicenciaUsoDelSuelo * superficie,
                DeslindeDeTerreno = factores.DeslindeDelTerreno * superficie,
                EstudioTopografico = factores.EstudioTopografico * superficie,
                MecanicaDeSuelos = factores.MecanicaDeSuelos * superficie,
                Autorizacion = factores.Autorizacion * superficie,
                Prediales = factores.Prediales * superficie,

                Kilo = factores.Kilo * superficie,
                Parque = factores.Parque * superficie,
                ArborizacionKiloYParque = factores.ArborizacionKiloYParque * superficie,
                BardaPerimetral = factores.BardaPerimetral * superficie,
                BardaDecorativa = factores.BardaDecorativa * superficie,
                MurosDeContencion = factores.MurosDeContención * superficie,

                Urbanizacion = factores.Urbanizacion * superficie
            };

            // Después calcular el TU total del desarrollador (que es temporal), y basado en eso le agregas costo de mantenimiento
            decimal tuTemporal = TuDesarrollador.TotalTU;
            decimal mantenimiento = tuTemporal * .0481M;
            TuDesarrollador.Mantenimiento = mantenimiento;

            // Basado en el nuevo TU total del desarrollador (tambien temporal), calcular y añadir el costo de adquisición de tierra para obtener el Tu final
            double tuDeReferencia = fracc.TuDeReferencia ?? fracc.TipoDeSuelo.TuDeReferencia ?? 0;
            decimal tuDesarrolladorPorM2 = TuDesarrollador.TotalTU / (decimal)fracc.MetrosVendibles;
            decimal precioVentaPorM2Vendible = (decimal)tuDeReferencia - tuDesarrolladorPorM2;
            decimal montoDeLaOperacion = precioVentaPorM2Vendible * (decimal)fracc.MetrosVendibles;
            decimal gastosDeAdquisicion = montoDeLaOperacion * 0.04M;
            TuDesarrollador.GastosDeAdquisicion = gastosDeAdquisicion;

            return TuDesarrollador;
        }
    }
}
