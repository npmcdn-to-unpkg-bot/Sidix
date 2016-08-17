using System;
using Dixus.BusinessRules.Inversiones;
using Dixus.BusinessRules.Inversiones.Entidades;
using Dixus.Repositorios.Abstract;
using Dixus.Entidades;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Dixus.BusinessRules.Inversiones
{

    public class CalculadoraPrecioUnitarioDeInversiones : ICalculadoraPrecioUnitarioDeInversiones
    {
        private readonly IUnitOfWork _unitofwork;
        public CalculadoraPrecioUnitarioDeInversiones(IUnitOfWork uowParam)
        {
            _unitofwork = uowParam;
        }

        public async Task<CobrosPorInversiones> CalcularTodosLosPreciosUnitarios()
        {
            decimal areaConsiderada = (decimal)(await _unitofwork.Fracciones.AreaConsideradaEnInversiones());
            
            return new CobrosPorInversiones()
            {
                Mvas = await CalcularPrecioPorMVA(),
                Lps = await CalcularPrecioPorLPS(),
                LpsSaneamiento =  await CalcularPrecioPorLPSSaneamiento(),
                Vialidades = await CalcularPrecioDeInversionesPorM2<InversionVialidades>(areaConsiderada),
                RedDigital = await CalcularPrecioDeInversionesPorM2<InversionRedDigital>(areaConsiderada),
                GasNatural = await CalcularPrecioDeInversionesPorM2<InversionGasNatural>(areaConsiderada),
                EstudiosYProyectos = await CalcularPrecioDeInversionesPorM2<InversionEstudiosYProyectos>(areaConsiderada),
                PostVenta = await CalcularPrecioDeInversionesPorM2<InversionPostVenta>(areaConsiderada),
                CostosIndirectos = await CalcularPrecioDeInversionesPorM2<InversionCostosIndirectosObra>(areaConsiderada),
                MovimientoDeTierra = await CalcularPrecioDeInversionesPorM2<InversionMovimientoTierra>(areaConsiderada),
                OtrasInversiones = await CalcularPrecioDeInversionesPorM2<InversionObrasEspeciales>(areaConsiderada)
            };
        }

        private async Task<decimal> CalcularPrecioDeInversionesPorM2<TInversion>(decimal areaConsiderada) where TInversion : Inversion
        {
            var montoTotalInvertido = await _unitofwork.Transacciones.SumarMontoTotalDeInversiones<TInversion>();
            return montoTotalInvertido / areaConsiderada;
        }
        private async Task<decimal> CalcularPrecioPorLPS()
        {
            var lpsConsiderables = await _unitofwork.Transacciones.GetLPSAConsiderar();
            var montoTotalInvertidoEnAgua = await _unitofwork.Transacciones.SumarMontoTotalDeInversiones<InversionAguaPotable>();

            return montoTotalInvertidoEnAgua / (decimal)lpsConsiderables;
        }
        private async Task<decimal> CalcularPrecioPorLPSSaneamiento()
        {
            var lpsSanemientoConsiderables = await _unitofwork.Transacciones.GetLPSSaneamientoAConsiderar();
            var montoTotalInvertidoEnSaneamiento = await _unitofwork.Transacciones.SumarMontoTotalDeInversiones<InversionSaneamiento>();

            return montoTotalInvertidoEnSaneamiento / (decimal)lpsSanemientoConsiderables;
        }
        private async Task<decimal> CalcularPrecioPorMVA()
        {
            var mvasConsiderables = await _unitofwork.Transacciones.GetMVAsAConsiderar();
            var montoTotalInvertidoEnElectricidad = await _unitofwork.Transacciones.SumarMontoTotalDeInversiones<InversionElectricidad>();

            return montoTotalInvertidoEnElectricidad / (decimal)mvasConsiderables;
        }
    }
}