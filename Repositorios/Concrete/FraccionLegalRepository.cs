using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Dixus.Repositorios.Abstract;
using Dixus.Entidades;
using Dixus.Domain;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Concrete
{
    public class FraccionLegalRepository : RepositoryBasic<FraccionLegal>, IFraccionLegalRepository
    {
        protected IQueryable<FraccionLegal> Subdivisiones;
        public FraccionLegalRepository(DixusContext context) : base(context)
        {
            Subdivisiones = context.FraccionesLegales.Where(sub => sub.Descontinuada == false);
        }

        public FraccionLegal ObtenerPorId(int id)
        {
            return Subdivisiones.SingleOrDefault(x => x.FraccionLegalId == id);
        }
        public FraccionLegal ObtenerPorId(Expression<Func<FraccionLegal, bool>> idexpression, params string[] propiedadesIncluidas)
        {
            var query = Subdivisiones;
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return query.SingleOrDefault(idexpression);
        }
        public IEnumerable<FraccionLegal> Obtener(params string[] propiedadesIncluidas)
        {
            var query = Subdivisiones;
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return query.ToList();
        }
        public IEnumerable<FraccionLegal> Filtrar(Expression<Func<FraccionLegal, bool>> filtros, params string[] propiedadesIncluidas)
        {
            var query = Subdivisiones.Where(filtros);
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return query.ToList();
        }

        public async Task<FraccionLegal> ObtenerPorIdAsync(int id)
        {
            return await Subdivisiones.SingleOrDefaultAsync(x => x.FraccionLegalId == id);
        }
        public async Task<FraccionLegal> ObtenerPorIdAsync(Expression<Func<FraccionLegal, bool>> idexpression, params string[] propiedadesIncluidas)
        {
            var query = Subdivisiones;
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return await query.SingleOrDefaultAsync(idexpression);
        }
        public async Task<IEnumerable<FraccionLegal>> ObtenerAsync(params string[] propiedadesIncluidas)
        {
            var query = Subdivisiones;
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<FraccionLegal>> FiltrarAsync(Expression<Func<FraccionLegal, bool>> filtros, params string[] propiedadesIncluidas)
        {
            var query = Subdivisiones.Where(filtros);
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<FraccionLegal>> ObtenerMasGrandes(int howmany)
        {
            return await Subdivisiones
               .OrderByDescending(x => x.Superficie)
               .Take(howmany)
               .ToListAsync();
        }
        public async Task<IEnumerable<FraccionLegal>> ObtenerMasChicas(int howmany)
        {
            return await Subdivisiones
               .OrderBy(x => x.Superficie)
               .Take(howmany)
               .ToListAsync();
        }
        public async Task<IEnumerable<FraccionLegal>> ObtenerPorCliente(int clienteid)
        {
            return await Subdivisiones
                .Where(sub =>
                    sub.Clientes != null &&
                    sub.Clientes.Count > 0 &&
                    sub.Clientes.Any(cli => cli.ClienteId == clienteid))
                .ToListAsync();
        }

        public async Task<double> AreaTotal()
        {
            return await Subdivisiones
                .SumAsync(x => x.Superficie);
        }
        public async Task<double> AreaPorCliente(int clienteid)
        {
            return await Subdivisiones
                .Where(sub =>
                    sub.Clientes != null &&
                    sub.Clientes.Count > 0 &&
                    sub.Clientes.Any(cli => cli.ClienteId == clienteid))
                .SumAsync(sub => sub.Superficie);
        }
    }

}
