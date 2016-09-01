using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Dixus.Repositorios.Abstract;
using Dixus.Entidades;
using Dixus.Domain;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Dixus.Repositorios.Concrete
{
    public class FraccionRepository : Repository<Fraccion>, IFraccionRepository
    {
        protected IQueryable<Fraccion> Fracciones;
        public FraccionRepository(DixusContext context) : base(context)
        {
            Fracciones = context.Fracciones.Where(x => x.Descontinuada == false);
        }

        public async Task<IEnumerable<Fraccion>> ObtenerComoEstabanEnFecha(DateTime fecha)
        {
            return await Fracciones.
                Where( x =>
                       x.FechaCreada < fecha &&
                       (!x.FechaDescontinuada.HasValue || x.FechaDescontinuada > fecha))
                .ToListAsync();
        }
        public async Task<IEnumerable<Fraccion>> ObtenerPorEtapa(int etapa)
        {
            return await Fracciones
                .Where(x => x.Etapa == etapa)
                .ToListAsync();
        }
        public async Task<IEnumerable<Fraccion>> ObtenerMasGastadorasDeEnergia(int howmany)
        {
            return await Fracciones
                .OrderByDescending(x => x.GetMvaRequeridos())
                .Take(howmany)
                .ToListAsync();
        }
        public async Task<IEnumerable<Fraccion>> ObtenerMasGastadorasDeAgua(int howmany)
        {
            return await Fracciones
                .OrderByDescending(x => x.GetLpsMedioDiarioAgua())
                .Take(howmany)
                .ToListAsync();
        }
        public async Task<IEnumerable<Fraccion>> ObtenerMasGrandes(int howmany)
        {
            return await Fracciones
                .OrderByDescending(x => x.MetrosCuadrados)
                .Take(howmany)
                .ToListAsync();
        }
        public async Task<IEnumerable<Fraccion>> ObtenerMasChicas(int howmany)
        {
            return await Fracciones
                .OrderBy(x => x.MetrosCuadrados)
                .Take(howmany)
                .ToListAsync();
        }
        public async Task<IEnumerable<Fraccion>> ObtenerDonadas()
        {
            return await Fracciones
                .Where(x =>
                       x.SubdivisionLegal != null &&
                       x.SubdivisionLegal.Estatus == EstatusDeSubdivision.Donada)
                .ToListAsync();
        }
        public async Task<IEnumerable<Fraccion>> ObtenerEnGarantia()
        {
            return await Fracciones
                .Where(x =>
                       x.SubdivisionLegal != null &&
                       x.SubdivisionLegal.Estatus == EstatusDeSubdivision.Garantia)
                .ToListAsync();
        }
        public async Task<IEnumerable<Fraccion>> ObtenerComprometidas()
        {
            return await Fracciones
                .Where(x =>
                       x.SubdivisionLegal != null &&
                       x.SubdivisionLegal.Estatus == EstatusDeSubdivision.Comprometida)
                .ToListAsync();
        }
        public async Task<IEnumerable<Fraccion>> ObtenerLibres()
        {
            return await Fracciones
                .Where(x =>
                       x.SubdivisionLegal == null ||
                       x.SubdivisionLegal.Estatus == EstatusDeSubdivision.Libre)
                .ToListAsync();
        }
        public async Task<IEnumerable<Fraccion>> ObtenerPorCliente(int clienteid)
        {
            return await Fracciones
                .Where( x =>
                        x.SubdivisionLegal != null &&
                        x.SubdivisionLegal.Clientes.Count() > 0 &&
                        x.SubdivisionLegal.Clientes.Any(cli => cli.ClienteId == clienteid))
                .ToListAsync();
        }
        public async Task<IEnumerable<FraccionVendible>> ObtenerPorVender()
        {
            return await Fracciones
                .OfType<FraccionVendible>()
                .Where( x =>
                        x.SubdivisionLegal == null || (
                        x.SubdivisionLegal.Estatus != EstatusDeSubdivision.Vendida &&
                        x.SubdivisionLegal.Estatus != EstatusDeSubdivision.Donada))
                .ToListAsync();
        }
        public async Task<IEnumerable<FraccionVendible>> ObtenerVendidas()
        {
            return await Fracciones
                .OfType<FraccionVendible>()
                .Where( x =>
                        x.SubdivisionLegal != null &&
                        x.SubdivisionLegal.Estatus == EstatusDeSubdivision.Vendida)
                .ToListAsync();
        }
        public async Task<IEnumerable<FraccionVendible>> ObtenerPorAñoDeVenta(int año)
        {
            return await Fracciones
                .OfType<FraccionVendible>()
                .Where(fracc => fracc.GetAñoDeVenta() == año)
                .ToListAsync();
        }
        public async Task<IEnumerable<FraccionVendible>> ObtenerEnRangoDeAños(int añoinicio, int añofinal)
        {
            return await Fracciones
                .OfType<FraccionVendible>()
                .Where( x =>
                        x.GetAñoDeVenta() >= añoinicio &&
                        x.GetAñoDeVenta() <= añofinal)
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccion>> Obtener<TFraccion>() where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccion>> ObtenerComoEstabanEnFecha<TFraccion>(DateTime fecha) where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .Where( x =>
                        x.FechaCreada < fecha &&
                        (!x.FechaDescontinuada.HasValue || x.FechaDescontinuada > fecha))
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccion>> ObtenerPorEtapa<TFraccion>(int etapa) where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .Where(x => x.Etapa == etapa)
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccion>> ObtenerMasGastadorasDeEnergia<TFraccion>(int howmany) where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .OrderByDescending(x => x.GetMvaRequeridos())
                .Take(howmany)
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccion>> ObtenerMasGastadorasDeAgua<TFraccion>(int howmany) where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .OrderByDescending(x => x.GetLpsMedioDiarioAgua())
                .Take(howmany)
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccion>> ObtenerMasGrandes<TFraccion>(int howmany) where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .OrderByDescending(x => x.MetrosCuadrados)
                .Take(howmany)
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccion>> ObtenerMasChicas<TFraccion>(int howmany) where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .OrderBy(x => x.MetrosCuadrados)
                .Take(howmany)
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccion>> ObtenerDonadas<TFraccion>() where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .Where(x =>
                       x.SubdivisionLegal != null &&
                       x.SubdivisionLegal.Estatus == EstatusDeSubdivision.Donada)
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccion>> ObtenerEnGarantia<TFraccion>() where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .Where(x =>
                       x.SubdivisionLegal != null &&
                       x.SubdivisionLegal.Estatus == EstatusDeSubdivision.Garantia)
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccion>> ObtenerComprometidas<TFraccion>() where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .Where(x =>
                       x.SubdivisionLegal != null &&
                       x.SubdivisionLegal.Estatus == EstatusDeSubdivision.Comprometida)
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccion>> ObtenerLibres<TFraccion>() where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .Where(x =>
                       x.SubdivisionLegal == null ||
                       x.SubdivisionLegal.Estatus == EstatusDeSubdivision.Libre)
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccion>> ObtenerPorCliente<TFraccion>(int clienteid) where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .Where(x =>
                       x.SubdivisionLegal != null &&
                       x.SubdivisionLegal.Clientes.Count() > 0 &&
                       x.SubdivisionLegal.Clientes.Any(cli => cli.ClienteId == clienteid))
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccionVendible>> ObtenerPorVender<TFraccionVendible>() where TFraccionVendible : FraccionVendible
        {
            return await Fracciones
                .OfType<TFraccionVendible>()
                .Where(x =>
                       x.SubdivisionLegal == null || (
                       x.SubdivisionLegal.Estatus != EstatusDeSubdivision.Vendida &&
                       x.SubdivisionLegal.Estatus != EstatusDeSubdivision.Donada))
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccionVendible>> ObtenerVendidas<TFraccionVendible>() where TFraccionVendible : FraccionVendible
        {
            return await Fracciones
                .OfType<TFraccionVendible>()
                .Where(x =>
                       x.SubdivisionLegal != null &&
                       x.SubdivisionLegal.Estatus == EstatusDeSubdivision.Vendida)
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccionVendible>> ObtenerPorAñoDeVenta<TFraccionVendible>(int año) where TFraccionVendible : FraccionVendible
        {
            return await Fracciones
                .OfType<TFraccionVendible>()
                .Where(fracc => fracc.GetAñoDeVenta() == año)
                .ToListAsync();
        }
        public async Task<IEnumerable<TFraccionVendible>> ObtenerEnRangoDeAños<TFraccionVendible>(int añoinicio, int añofinal) where TFraccionVendible : FraccionVendible
        {
            return await Fracciones
                .OfType<TFraccionVendible>()
                .Where(x =>
                       x.GetAñoDeVenta() >= añoinicio &&
                       x.GetAñoDeVenta() <= añofinal)
                .ToListAsync();
        }

        public async Task<double> AreaTotal()
        {
            return await Fracciones
                .SumAsync(x => x.MetrosCuadrados);
        }
        public async Task<double> AreaPorTipoDeSuelo(int tipodesueloId)
        {
            return await Fracciones
                .Where( x => x.TipoDeSueloId == tipodesueloId)
                .SumAsync(x => x.MetrosCuadrados);
        }
        public async Task<double> AreaConsideradaEnInversiones()
        {
            return await Fracciones
                .Where(x =>
                     x is FraccionVendible &&
                     (x.CalculosEspeciales == null || x.CalculosEspeciales.SeExcluyeDeCobroDeInversiones == false))
                .SumAsync(x => x.MetrosCuadrados);
        }
        public async Task<double> AreaExlcuidaDeInversiones()
        {
            return await Fracciones
                .Where(x =>
                    x is FraccionNoVendibles ||
                    x.CalculosEspeciales != null && x.CalculosEspeciales.SeExcluyeDeCobroDeInversiones == true)
                .SumAsync(x => x.MetrosCuadrados);
        }
        public async Task<double> AreaPorEtapa(int etapa)
        {
            return await Fracciones
                .Where(x => x.Etapa == etapa)
                .SumAsync(x => x.MetrosCuadrados);
        }
        public async Task<double> AreaPorCliente(int clienteid)
        {
            return await Fracciones
                .Where(x =>
                       x.SubdivisionLegal != null &&
                       x.SubdivisionLegal.Clientes.Count() > 0 &&
                       x.SubdivisionLegal.Clientes.Any(cli => cli.ClienteId == clienteid))
                .SumAsync( fracc => fracc.MetrosCuadrados);
        }
        public async Task<double> AreaTotal<TFraccion>() where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .SumAsync(x => x.MetrosCuadrados);
        }
        public async Task<double> AreaPorEtapa<TFraccion>(int etapa) where TFraccion : Fraccion
        {
            return await Fracciones
                .OfType<TFraccion>()
                .Where(x => x.Etapa == etapa)
                .SumAsync(x => x.MetrosCuadrados);
        }
        public async Task<double> AreaPorCliente<TFraccion>(int clienteid) where TFraccion : FraccionVivienda
        {
            return await Fracciones
                .OfType<TFraccion>()
                .Where(x =>
                       x.SubdivisionLegal != null &&
                       x.SubdivisionLegal.Clientes.Count() > 0 &&
                       x.SubdivisionLegal.Clientes.Any(cli => cli.ClienteId == clienteid))
                .SumAsync(fracc => fracc.MetrosCuadrados);
        }

        public async Task<int> NumeroDeViviendasDesarrolladas()
        {
            return await Fracciones
                .OfType<FraccionVivienda>()
                .Where(x => x.ViviendasDesarrolladas.HasValue)
                .SumAsync(x => x.ViviendasDesarrolladas.Value);
        }
        public async Task<int> NumeroDeViviendasEnProceso()
        {
            return await Fracciones
                .OfType<FraccionVivienda>()
                .Where(x => x.ViviendasEnProceso.HasValue)
                .SumAsync(x => x.ViviendasEnProceso.Value);
        }
        public async Task<int> NumeroDeViviendasPorDesarrollar()
        {
            return await Fracciones
                .OfType<FraccionVivienda>()
                .Where(x => x.ViviendasPorDesarrollar.HasValue)
                .SumAsync(x => x.ViviendasPorDesarrollar.Value);
        }
        public async Task<int> NumeroDeViviendasTotales()
        {
            return await Fracciones
                .OfType<FraccionVivienda>()
                .SumAsync(x => x.ViviendasTotales);
        }
        public async Task<int> NumeroDeViviendasDesarrolladas<TFraccionVivienda>() where TFraccionVivienda : FraccionVivienda
        {
            return await Fracciones
                .OfType<TFraccionVivienda>()
                .Where(x => x.ViviendasDesarrolladas.HasValue)
                .SumAsync(x => x.ViviendasDesarrolladas.Value);
        }
        public async Task<int> NumeroDeViviendasEnProceso<TFraccionVivienda>() where TFraccionVivienda : FraccionVivienda
        {
            return await Fracciones
                .OfType<TFraccionVivienda>()
                .Where(x => x.ViviendasEnProceso.HasValue)
                .SumAsync(x => x.ViviendasEnProceso.Value);
        }
        public async Task<int> NumeroDeViviendasPorDesarrollar<TFraccionVivienda>() where TFraccionVivienda : FraccionVivienda
        {
            return await Fracciones
                .OfType<TFraccionVivienda>()
                .Where(x => x.ViviendasPorDesarrollar.HasValue)
                .SumAsync(x => x.ViviendasPorDesarrollar.Value);
        }
        public async Task<int> NumeroDeViviendasTotales<TFraccionVivienda>() where TFraccionVivienda : FraccionVivienda
        {
            return await Fracciones
                .OfType<TFraccionVivienda>()
                .SumAsync(x => x.ViviendasTotales);
        }

       
    }

}
