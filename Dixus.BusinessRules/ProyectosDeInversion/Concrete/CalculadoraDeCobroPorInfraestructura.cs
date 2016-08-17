using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dixus.BusinessRules.Inversiones;
using Dixus.BusinessRules.Inversiones.Entidades;
using Dixus.Entidades;

namespace Dixus.BusinessRules.ProyectosDeInversion
{
    public class CalculadoraDeCobroPorInfraestructura : ICalculadoraDeCobroPorInfraestructura
    {
        private ICalculadoraPrecioUnitarioDeInversiones _calc;
        public CalculadoraDeCobroPorInfraestructura(ICalculadoraPrecioUnitarioDeInversiones calcParam)
        {
            _calc = calcParam;
        }

        public async Task<CobrosPorInversiones> CalcularCobroDeInfraestructuraAFraccion(FraccionVendible fracc)
        {
            decimal metrosCuadrados = (decimal)fracc.MetrosCuadrados;
            CobrosPorInversiones cobrosPorUnidad = await _calc.CalcularTodosLosPreciosUnitarios();

            return new CobrosPorInversiones()
            {
                CostosIndirectos = cobrosPorUnidad.CostosIndirectos * metrosCuadrados,
                EstudiosYProyectos = cobrosPorUnidad.EstudiosYProyectos * metrosCuadrados,
                GasNatural = cobrosPorUnidad.GasNatural * metrosCuadrados,
                MovimientoDeTierra = cobrosPorUnidad.MovimientoDeTierra * metrosCuadrados,
                OtrasInversiones = cobrosPorUnidad.OtrasInversiones * metrosCuadrados,
                PostVenta = cobrosPorUnidad.PostVenta * metrosCuadrados,
                RedDigital = cobrosPorUnidad.RedDigital * metrosCuadrados,
                Vialidades = cobrosPorUnidad.Vialidades * metrosCuadrados,
                Lps = cobrosPorUnidad.Lps * (decimal)fracc.GetLpsMedioDiarioAgua(),
                LpsSaneamiento = cobrosPorUnidad.LpsSaneamiento * (decimal)fracc.GetLpsMedioDiarioSaneamiento(),
                Mvas = cobrosPorUnidad.Mvas * (decimal)fracc.GetMvaRequeridos(),
            };
        }
    }
}
