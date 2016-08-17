using Dixus.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Abstract
{
    public interface ITransaccionRepository : IRepository<Transaccion>
    {
        // INVERSIONES
        Task<IEnumerable<Inversion>> ObtenerInversiones();
        Task<IEnumerable<Inversion>> ObtenerInversionesRecientes(int howmnay);
        Task<IEnumerable<Inversion>> ObtenerInversionesDeDia(int año, int mes, int dia);
        Task<IEnumerable<Inversion>> ObtenerInversionesDeMes(int año, int mes);
        Task<IEnumerable<Inversion>> ObtenerInversionesDeAño(int año);
        Task<IEnumerable<TInversion>> ObtenerInversiones<TInversion>() where TInversion : Inversion;
        Task<IEnumerable<TInversion>> ObtenerInversionesRecientes<TInversion>(int homwnay) where TInversion : Inversion;
        // DINERO INVERTIDO
        Task<decimal> SumarMontoTotalDeInversiones();
        Task<decimal> SumarMontoTotalDeInversiones<TInversion>() where TInversion : Inversion;
        Task<decimal> GetMontoAConsiderarAguaPotable();
        Task<decimal> GetMontoAConsiderarSaneamiento();

        // INGRESOS
        Task<IEnumerable<Ingreso>> ObtenerIngresos();
        Task<IEnumerable<Ingreso>> ObtenerIngresosRecientes(int howmnay);
        Task<IEnumerable<Ingreso>> ObtenerIngresosDeDia(int año, int mes, int dia);
        Task<IEnumerable<Ingreso>> ObtenerIngresosDeMes(int año, int mes);
        Task<IEnumerable<Ingreso>> ObtenerIngresosDeAño(int año);
        Task<IEnumerable<TIngreso>> ObtenerIngresos<TIngreso>() where TIngreso : Ingreso;
        Task<IEnumerable<TIngreso>> ObtenerIngresosRecientes<TIngreso>(int howmany) where TIngreso : Ingreso;
        // DINERO INGRESADO
        Task<decimal> SumarMontoTotalDeIngresos();
        Task<decimal> SumarMontoTotalDeIngresos<TIngreso>() where TIngreso : Ingreso;



        // RECURSOS OBTENIDOS RESULTADO DE INVERSIONES
        /// <summary>
        /// Regresa la cantidad total de Mega-voltios-amperes (MVAs) disponibles en el proyecto resultantes de las inversiones hechas en electricidad. </summary>
        /// <returns></returns>
        Task<double> GetMVAsTotal();
        /// <summary>
        /// Regresa la cantidad total de Litros por segundo (LPS) disponibles en el proyecto resultantes de las inversiones hechas en agua potable.
        /// </summary>
        /// <returns></returns>
        Task<double> GetLPSTotal();
        /// <summary>
        /// Regresa la cantidad total de Litros por segundo (LPS) destinados a saneamiento disponibles en el proyecto resultantes de las inversiones hechas en saneamiento.
        /// </summary>
        /// <returns></returns>
        Task<double> GetLPSSaneamientoTotal();

        /// <summary>
        /// Regresa la cantidad de MVAs usados en la formula para calcular el precio por MVA, que resultan de restar las obras hechas aparte (como la de Espacio y Derex) y los MVAs incobrables (como a Mascareñas y fracciones no vendibles), al total de MVAs
        /// </summary>
        /// <returns></returns>
        Task<double> GetMVAsAConsiderar();
        /// <summary>
        /// Regresa la cantidad de Litros por segundo (LPS) usados en la formula para calcular el precio por LPS, que resultan de restar las obras hechas aparte (como la de Espacio y Derex) y los LPS incobrables (como a Mascareñas y fracciones no vendibles), al total de LPS del proyecto
        /// </summary>
        /// <returns>Mucho</returns>
        Task<double> GetLPSAConsiderar();
        /// <summary>
        /// Regresa la cantidad de Litros por segundo (LPS) destinados a saneamiento usados en la formula para calcular el precio por LPS, que resultan de restar las obras hechas aparte (como la de Espacio y Derex) y los LPS incobrables (como a Mascareñas y fracciones no vendibles), al total de LPS de saneamiento del proyecto
        /// </summary>
        /// <returns></returns>
        Task<double> GetLPSSaneamientoAConsiderar();


     
    }
}
