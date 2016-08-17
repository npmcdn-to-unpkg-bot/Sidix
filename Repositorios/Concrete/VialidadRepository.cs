using System;
using System.Collections.Generic;
using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using System.Linq;
using Dixus.Entidades.Identity;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Dixus.Repositorios.Concrete
{
    public class VialidadRepository : RepositoryBasic<Vialidad>, IVialidadRepository
    {
        protected IQueryable<Vialidad> Vialidades;
        public VialidadRepository(DixusContext context) : base(context)
        {
            Vialidades = context.Vialidades.Where(x => x.Descontinuada == false);
        }

        public Vialidad ObtenerPorId(int id)
        {
            return Vialidades.SingleOrDefault(x => x.VialidadId == id);
        }
        public Vialidad ObtenerPorId(Expression<Func<Vialidad, bool>> idexpression, params string[] propiedadesIncluidas)
        {
            var query = Vialidades;
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return query.SingleOrDefault(idexpression);
        }
        public IEnumerable<Vialidad> Obtener(params string[] propiedadesIncluidas)
        {
            var query = Vialidades;
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return query.ToList();
        }
        public IEnumerable<Vialidad> Filtrar(Expression<Func<Vialidad, bool>> filtros, params string[] propiedadesIncluidas)
        {
            var query = Vialidades.Where(filtros);
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return query.ToList();
        }

        public async Task<Vialidad> ObtenerPorIdAsync(int id)
        {
            return await Vialidades.SingleOrDefaultAsync(x => x.VialidadId == id);
        }
        public async Task<Vialidad> ObtenerPorIdAsync(Expression<Func<Vialidad, bool>> idexpression, params string[] propiedadesIncluidas)
        {
            var query = Vialidades;
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return await query.SingleOrDefaultAsync(idexpression);
        }
        public async Task<IEnumerable<Vialidad>> ObtenerAsync(params string[] propiedadesIncluidas)
        {
            var query = Vialidades;
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Vialidad>> FiltrarAsync(Expression<Func<Vialidad, bool>> filtros, params string[] propiedadesIncluidas)
        {
            var query = Vialidades.Where(filtros);
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Vialidad>> ObtenerPorNumeroDeCarriles(int numeroDeCarriles)
        {
            return await Vialidades.Where(vial => vial.NumeroDeCarriles == numeroDeCarriles).ToListAsync();
        }
    }
}
