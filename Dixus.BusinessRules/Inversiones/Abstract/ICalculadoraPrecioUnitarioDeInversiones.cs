
using Dixus.BusinessRules.Inversiones.Entidades;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.Inversiones
{
    public interface ICalculadoraPrecioUnitarioDeInversiones
    {
        Task<CobrosPorInversiones> CalcularTodosLosPreciosUnitarios();
        //Task<decimal> CalcularPrecioPorMVA();
        //Task<decimal> CalcularPrecioPorLPS();
        //Task<decimal> CalcularPrecioPorLPSSaneamiento();
        //Task<decimal> CalcularPrecioDeVialidadesPorM2();
        //Task<decimal> CalcularPrecioDeRedDigitalPorM2();
        //Task<decimal> CalcularPrecioDeGasNaturalPorM2();
        //Task<decimal> CalcularPrecioDeEstudiosYProyectosPorM2();
        //Task<decimal> CalcularPrecioDePostVentaPorM2();
        //Task<decimal> CalcularPrecioDeCostosIndirectosPorM2();
        //Task<decimal> CalcularPrecioDeOtrasInversionesPorM2();
        //Task<decimal> CalcularPrecioDeMovimientoDeTierraPorM2();
    }                                           
  
}
