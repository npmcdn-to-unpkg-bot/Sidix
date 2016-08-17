using Dixus.Entidades;
using Dixus.BusinessRules.ProyectosDeInversion.Entidades;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.ProyectosDeInversion
{
    public class CalculadoraDeProyectosDeInversion : ICalculadoraDeProyectosDeInversion
    {
        public ICalculadoraDeCostosTU CalculadoraCostosDetu { get; set; }
        public CalculadoraDeProyectosDeInversion(ICalculadoraDeCostosTU calcParam)
        {
            CalculadoraCostosDetu = calcParam;
        }

        public async Task<InfoCompletaProyectosDeInversion> CalcularDesgloseYTu(FraccionVendible fraccion)
        {
            TuMacronanzanaYDesarrollador TuSummary = await CalculadoraCostosDetu.CalcularTuDeFraccion(fraccion);

            AnalisisDePrecioDeVenta InfoDeVenta = new AnalisisDePrecioDeVenta()
            {
                TuDeReferencia = (decimal)(fraccion.TuDeReferencia ?? fraccion.TipoDeSuelo.TuDeReferencia ?? 0),
                TuDelDesarrollador = TuSummary.TuDesarrollador.TotalTU / (decimal)fraccion.MetrosVendibles,
                SuperficieVendible = fraccion.MetrosVendibles,
                SuperficieTotal = fraccion.MetrosCuadrados,
                Costos = TuSummary.TuMacromanzana.TotalTU
            };

            InfoDeVenta = AñadirInfoDeCalculosADesglose(InfoDeVenta);

            return new InfoCompletaProyectosDeInversion()
            {
                DesgloseFinal = InfoDeVenta,
                TuCompleto = TuSummary
            };
        }

        private AnalisisDePrecioDeVenta AñadirInfoDeCalculosADesglose(AnalisisDePrecioDeVenta desglose)
        {
            desglose.PrecioDeVentaPorM2Vendible = desglose.TuDeReferencia - desglose.TuDelDesarrollador;
            desglose.MontoDeLaOperacion = desglose.PrecioDeVentaPorM2Vendible * (decimal)desglose.SuperficieVendible;
            desglose.PrecioDeVentaM2PorValorResidual = desglose.MontoDeLaOperacion / (decimal)desglose.SuperficieTotal;
            desglose.Ingresos = desglose.MontoDeLaOperacion;
            desglose.UtilidadBruta = desglose.Ingresos - desglose.Costos;
            desglose.MargenBruto = (double)(desglose.UtilidadBruta / desglose.Ingresos);
            desglose.GAV = desglose.Ingresos * 0.10M;
            desglose.CIF = desglose.Ingresos * 0.03M;
            desglose.UtilidadAntesDeImpuestos = desglose.UtilidadBruta - desglose.GAV - desglose.CIF;
            desglose.Impuestos = desglose.UtilidadAntesDeImpuestos * 0.30M;
            desglose.UtilidadNeta = desglose.UtilidadAntesDeImpuestos - desglose.Impuestos;
            desglose.MargenNeto = (double)(desglose.UtilidadNeta / desglose.Ingresos);

            return desglose;
        }






    }
}
