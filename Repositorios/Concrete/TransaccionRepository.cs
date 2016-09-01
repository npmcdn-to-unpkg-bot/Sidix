using System;
using System.Collections.Generic;
using System.Linq;
using Dixus.Domain;
using Dixus.Repositorios.Abstract;
using Dixus.Entidades;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Dixus.Repositorios.Concrete
{
    public class TransaccionRepository : Repository<Transaccion>, ITransaccionRepository
    {
        public TransaccionRepository(DixusContext context) : base(context)
        {

        }

        // INVERSIONES
        public async Task<IEnumerable<Inversion>> ObtenerInversiones()
        {
            return await EntityQuery.OfType<Inversion>()
                .ToListAsync();
        }
        public async Task<IEnumerable<Inversion>> ObtenerInversionesRecientes(int howmany)
        {
            return await EntityQuery.OfType<Inversion>()
                .OrderByDescending(x => x.FechaDeTransaccion)
                .Take(howmany)
                .ToListAsync();
        }
        public async Task<IEnumerable<Inversion>> ObtenerInversionesDeDia(int año, int mes, int dia)
        {
            return await EntityQuery.OfType<Inversion>()
                .Where(x =>
                       x.FechaDeTransaccion.Day == dia &&
                       x.FechaDeTransaccion.Month == mes &&
                       x.FechaDeTransaccion.Year == año)
                .ToListAsync();
        }
        public async Task<IEnumerable<Inversion>> ObtenerInversionesDeMes(int año, int mes)
        {
            return await EntityQuery.OfType<Inversion>()
                .Where(x =>
                       x.FechaDeTransaccion.Month == mes &&
                       x.FechaDeTransaccion.Year == año)
                .ToListAsync();
        }
        public async Task<IEnumerable<Inversion>> ObtenerInversionesDeAño(int año)
        {
            return await EntityQuery.OfType<Inversion>()
                .Where(x => x.FechaDeTransaccion.Year == año)
                .ToListAsync();
        }
        public async Task<IEnumerable<TInversion>> ObtenerInversiones<TInversion>() where TInversion : Inversion
        {
            return await EntityQuery.OfType<Inversion>()
                .OfType<TInversion>()
                .ToListAsync();
        }
        public async Task<IEnumerable<TInversion>> ObtenerInversionesRecientes<TInversion>(int howmany) where TInversion : Inversion
        {
            return await EntityQuery.OfType<Inversion>()
                .OfType<TInversion>()
                .OrderByDescending(x => x.FechaDeTransaccion)
                .Take(howmany)
                .ToListAsync();
        }
        public async Task<decimal> SumarMontoTotalDeInversiones()
        {
            return await EntityQuery.OfType<Inversion>()
                .SumAsync(inv => inv.Monto);
        }
        public async Task<decimal> SumarMontoTotalDeInversiones<TInversion>() where TInversion : Inversion
        {
            return await EntityQuery.OfType<Inversion>()
                .OfType<TInversion>().SumAsync(inv => inv.Monto);
        }
        //public async Task<decimal> GetMontoAConsiderarAguaPotable()
        //{
        //    var MontoTotal = SumarMontoTotalDeInversiones<InversionAguaPotable>();
        //    var MontoDestinadoAObrasAparte = DixusContext.Fracciones
        //        .Where(x => x.CalculosEspeciales.HizoObrasAguaAparte)
        //        .SumAsync(x => x.GetLpsMedioDiarioAgua());
        //    await Task.WhenAll(MontoTotal, MontoDestinadoAObrasAparte);
        //    return MontoTotal.Result - (decimal)MontoDestinadoAObrasAparte.Result;

        //}
        //public async Task<decimal> GetMontoAConsiderarSaneamiento()
        //{
        //    var MontoTotal = SumarMontoTotalDeInversiones<InversionSaneamiento>();
        //    var MontoDestinadoAObrasAparte = DixusContext.Fracciones
        //        .Where(x => x.CalculosEspeciales.HizoObrasAguaAparte)
        //        .SumAsync(x => x.GetLpsMedioDiarioSaneamiento());
        //    await Task.WhenAll(MontoTotal, MontoDestinadoAObrasAparte);
        //    return MontoTotal.Result - (decimal)MontoDestinadoAObrasAparte.Result;
        //}

        // INGRESOS
        public async Task<IEnumerable<Ingreso>> ObtenerIngresos()
        {
            return await EntityQuery.OfType<Ingreso>()
                .ToListAsync();
        }
        public async Task<IEnumerable<Ingreso>> ObtenerIngresosRecientes(int howmany)
        {
            return await EntityQuery.OfType<Ingreso>()
               .OrderByDescending(x => x.FechaDeTransaccion)
               .Take(howmany)
               .ToListAsync();
        }
        public async Task<IEnumerable<Ingreso>> ObtenerIngresosDeDia(int año, int mes, int dia)
        {
            return await EntityQuery.OfType<Ingreso>()
               .Where(x =>
                      x.FechaDeTransaccion.Day == dia &&
                      x.FechaDeTransaccion.Month == mes &&
                      x.FechaDeTransaccion.Year == año)
               .ToListAsync();
        }
        public async Task<IEnumerable<Ingreso>> ObtenerIngresosDeMes(int año, int mes)
        {
            return await EntityQuery.OfType<Ingreso>()
              .Where(x =>
                     x.FechaDeTransaccion.Month == mes &&
                     x.FechaDeTransaccion.Year == año)
              .ToListAsync();
        }
        public async Task<IEnumerable<Ingreso>> ObtenerIngresosDeAño(int año)
        {
            return await EntityQuery.OfType<Ingreso>()
              .Where(x => x.FechaDeTransaccion.Year == año)
              .ToListAsync();
        }
        public async Task<IEnumerable<TIngreso>> ObtenerIngresos<TIngreso>() where TIngreso : Ingreso
        {
            return await EntityQuery
                .OfType<TIngreso>()
                .ToListAsync();
        }
        public async Task<IEnumerable<TIngreso>> ObtenerIngresosRecientes<TIngreso>(int howmany) where TIngreso : Ingreso
        {
            return await EntityQuery
                .OfType<TIngreso>()
                .OrderByDescending(x => x.FechaDeTransaccion)
                .Take(howmany).ToListAsync();
        }
        public async Task<decimal> SumarMontoTotalDeIngresos()
        {
            return await EntityQuery
               .SumAsync(x => x.Monto);
        }
        public async Task<decimal> SumarMontoTotalDeIngresos<TIngreso>() where TIngreso : Ingreso
        {
            return await EntityQuery
               .OfType<TIngreso>()
               .SumAsync(x => x.Monto);
        }

        public async Task<double> GetMVAsTotal()
        {
            return await EntityQuery.OfType<Inversion>()
                .OfType<InversionElectricidad>()
                .Where(x => x.MvAsAportados.HasValue)
                .SumAsync(x => x.MvAsAportados.Value);
        }
        //public async Task<double> GetMVAsAConsiderar()
        //{
        //    var MvasTotales = await GetMVAsTotal();
        //    var fraccionesALasQueSeLesRegala = await DixusContext.Fracciones
        //                            .Where(x => x.CalculosEspeciales.NoSeLeCobraEnergia)
        //                            .ToListAsync();
        //    var MvasRegalados = fraccionesALasQueSeLesRegala.Sum(x => x.GetMvaRequeridos());
        //    //var MvasDestinadosAObrasAparte = DixusContext.Fracciones.Where(x => x.CalculosEspeciales.HizoObrasEnergiaAparte).Sum(x => x.GetMvaRequeridos());
        //    return MvasTotales - MvasRegalados;
        //}
        public async Task<double> GetLPSTotal()
        {
            return await EntityQuery
                .OfType<InversionAguaPotable>()
                .Where(x => x.LpsAportados.HasValue)
                .SumAsync(x => x.LpsAportados.Value);
        }
        //public async Task<double> GetLPSAConsiderar()
        //{
        //    var LpsTotales = await GetLPSTotal();

        //    var fraccionesALasQueSeLesRegala = await DixusContext.Fracciones.Where(x => x.CalculosEspeciales.NoSeLeCobraAgua).ToListAsync();
        //    var LpsRegalados = fraccionesALasQueSeLesRegala.Sum(x => x.GetLpsMedioDiarioAgua());

        //    var fraccionesConObrasAparte = await DixusContext.Fracciones.Where(x => x.CalculosEspeciales.HizoObrasAguaAparte).ToListAsync();
        //    var LpsDestinadosAObrasAparte = fraccionesConObrasAparte.Sum(x => x.GetLpsMedioDiarioAgua());

        //    return LpsTotales - LpsRegalados - LpsDestinadosAObrasAparte;
        //}
        public async Task<double> GetLPSSaneamientoTotal()
        {
            return await EntityQuery
                .OfType<InversionSaneamiento>()
                .Where(x => x.LpsSaneamientoAportados.HasValue)
                .SumAsync(x => x.LpsSaneamientoAportados.Value);
        }
        //public async Task<double> GetLPSSaneamientoAConsiderar()
        //{
        //    var LpsTotales = await GetLPSSaneamientoTotal();

        //    var fraccionesALasQueSeLesRegala = await DixusContext.Fracciones.Where(x => x.CalculosEspeciales.NoSeLeCobraAgua).ToListAsync();
        //    var LpsRegalados = fraccionesALasQueSeLesRegala.Sum(x => x.GetLpsMedioDiarioSaneamiento());

        //    var fraccionesConObrasAparte = await DixusContext.Fracciones.Where(x => x.CalculosEspeciales.HizoObrasAguaAparte).ToListAsync();
        //    var LpsDestinadosAObrasAparte = fraccionesConObrasAparte.Sum(x => x.GetLpsMedioDiarioSaneamiento());

        //    return LpsTotales - LpsRegalados - LpsDestinadosAObrasAparte;
        //}
        
    }
}
