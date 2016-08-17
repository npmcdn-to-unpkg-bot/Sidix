using System;
using System.Linq;
using Dixus.BusinessRules.Inversiones;
using Dixus.BusinessRules.ProyectosDeInversion.Entidades;
using Dixus.Entidades;
using Dixus.BusinessRules.Inversiones.Entidades;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.ProyectosDeInversion
{
    public class CalculadoraDeCostosTUFormaNueva : ICalculadoraDeCostosTU
    {
        private ICalculadoraPorcentajesDeTu _calc;
        public CalculadoraDeCostosTUFormaNueva(ICalculadoraPorcentajesDeTu calcParam, FactoresDeTu factores)
        {
            _calc = calcParam;
        }

        public async Task<TuMacronanzanaYDesarrollador> CalcularTuDeFraccion(FraccionVendible _fracc)
        {
            await Task.Run(() => { } );

            TuIndividual TuDesarrollador = ObtenerTuDelDesarrollador();
            TuIndividual TuMacromanzana = ObtenerTuDeMacromanzana();            
            return new TuMacronanzanaYDesarrollador(TuDesarrollador, TuMacromanzana);
        }

        private TuIndividual ObtenerTuDeMacromanzana()
        {
            return new TuIndividual();
        }

        private TuIndividual ObtenerTuDelDesarrollador()
        {
            return new TuIndividual();
        }
    }
}
