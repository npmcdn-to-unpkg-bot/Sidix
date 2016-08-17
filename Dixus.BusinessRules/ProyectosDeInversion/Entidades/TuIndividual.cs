
namespace Dixus.BusinessRules.ProyectosDeInversion.Entidades
{
    public class TuIndividual
    {
        // Tierra
        public decimal AdquisicionDeTierra { get; set; }
        public decimal GastosDeAdquisicion { get; set; }
        public decimal GastosNotariales { get; set; }
        public decimal TotalTierra
        {
            get
            {
                return AdquisicionDeTierra + GastosDeAdquisicion + GastosNotariales;
            }
        }

        // Gastos Por Fraccionar
        public decimal ProyectoPlanMaestro { get; set; }
        public decimal PresupuestoYUrbanizacion { get; set; }
        public decimal ImpactoAmbiental { get; set; }
        public decimal AutorizacionImpactoAmbiental { get; set; }
        public decimal RasantesAguaPotableYDrenaje { get; set; }
        public decimal LicenciaUsoDeSuelo { get; set; }
        public decimal DeslindeDeTerreno { get; set; }
        public decimal EstudioTopografico { get; set; }
        public decimal EstudioInundabilidad { get; set; }
        public decimal MecanicaDeSuelos { get; set; }
        public decimal Autorizacion { get; set; }
        public decimal Prediales { get; set; }
        public decimal DerechosConexionAguaYDrenaje { get; set; }
        public decimal DerechosCFE { get; set; }
        public decimal TotalGastosPorFraccionar
        {
            get
            {
                decimal result = 0;
                result += ProyectoPlanMaestro;
                result += PresupuestoYUrbanizacion;
                result += ImpactoAmbiental;
                result += AutorizacionImpactoAmbiental;
                result += RasantesAguaPotableYDrenaje;
                result += LicenciaUsoDeSuelo;
                result += DeslindeDeTerreno;
                result += EstudioTopografico;
                result += EstudioInundabilidad;
                result += MecanicaDeSuelos;
                result += Autorizacion;
                result += Prediales;
                result += DerechosConexionAguaYDrenaje;
                result += DerechosCFE;
                return result;
            }            
        }                

        // Infraestructura
        public decimal EnergiaElectrica { get; set; }
        public decimal AguaPotable { get; set; }
        public decimal Saneamiento { get; set; }
        public decimal Vialidades { get; set; }
        public decimal ObrasEspeciales { get; set; }
        public decimal RedDigital { get; set; }
        public decimal GasNatural { get; set; }
        public decimal MovimientoDeTierra { get; set; }
        public decimal CostosIndirectos { get; set; }
        public decimal TotalInfraestructura
        {
            get
            {
                decimal result = 0;
                result += EnergiaElectrica;
                result += AguaPotable;
                result += Saneamiento;
                result += Vialidades;
                result += ObrasEspeciales;
                result += RedDigital;
                result += GasNatural;
                result += MovimientoDeTierra;
                result += CostosIndirectos;
                return result;
            }
        }

        // Obras especiales
        public decimal Kilo { get; set; }
        public decimal Parque { get; set; }
        public decimal ArborizacionKiloYParque { get; set; }
        public decimal BardaPerimetral { get; set; }
        public decimal BardaDecorativa { get; set; }
        public decimal MurosDeContencion { get; set; }
        public decimal TotalObrasEspeciales
        {
            get
            {
                decimal result = 0;
                result += Kilo;
                result += Parque;
                result += ArborizacionKiloYParque;
                result += BardaPerimetral;
                result += BardaDecorativa;
                result += MurosDeContencion;
                return result;
            }
        }

        //Urbanizacion
        public decimal Urbanizacion { get; set; }
        public decimal TotalUrbanizacion => Urbanizacion;

        // Post venta
        public decimal Vigilancia { get; set; }
        public decimal Mantenimiento { get; set; }
        public decimal TotalPostVenta => Vigilancia + Mantenimiento;

        public decimal TotalTU
        {
            get
            {
                decimal result = 0;

                result += TotalTierra;
                result += TotalGastosPorFraccionar;
                result += TotalInfraestructura;
                result += TotalObrasEspeciales;
                result += TotalUrbanizacion;
                result += TotalPostVenta;

                return result;
            }
        }
    }
}

