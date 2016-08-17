using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Dixus.Repositorios.Abstract;
using Dixus.Entidades;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.IO;
using Dixus.Repositorios.Concrete;

namespace Dixus.Repositorios.Concrete
{
    public abstract class Repository<TEntity> : RepositoryBasic<TEntity>, IRepository<TEntity> where TEntity : Entidad
    {
        protected readonly DbContext Context;
        public Repository(DbContext context) : base(context)
        {
            Context = context;
        }

        public virtual TEntity ObtenerPorId(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public virtual TEntity ObtenerPorId(Expression<Func<TEntity, bool>> idexpression, params string[] propiedadesIncluidas)
        {
            IQueryable<TEntity> set = Context.Set<TEntity>();
            foreach( var propiedad in propiedadesIncluidas)
            {
                set = set.Include(propiedad);
            }
            return set.SingleOrDefault(idexpression);
        }
        public virtual IEnumerable<TEntity> Obtener(params string[] propiedadesIncluidas)
        {
            IQueryable<TEntity> set = Context.Set<TEntity>();
            foreach (var prop in propiedadesIncluidas)
                set = set.Include(prop);
            return set.ToList();
        }
        public virtual IEnumerable<TEntity> Filtrar(Expression<Func<TEntity, bool>> filtro, params string[] propiedadesIncluidas)
        {
            IQueryable<TEntity> set = Context.Set<TEntity>().Where(filtro);
            foreach (var prop in propiedadesIncluidas)
                set = set.Include(prop);
            return set.ToList();
        }
        
        public virtual async Task<TEntity> ObtenerPorIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }
        public virtual async Task<TEntity> ObtenerPorIdAsync(Expression<Func<TEntity, bool>> idexpression, params string[] propiedadesIncluidas)
        {
            IQueryable<TEntity> set = Context.Set<TEntity>();
            foreach (var propiedad in propiedadesIncluidas)
            {
                set = set.Include(propiedad);
            }
            return await set.SingleOrDefaultAsync(idexpression);
        }
        public virtual async Task<IEnumerable<TEntity>> ObtenerAsync(params string[] propiedadesIncluidas)
        {
            IQueryable<TEntity> set = Context.Set<TEntity>();
            foreach (var prop in propiedadesIncluidas)
                set = set.Include(prop);
            return await set.ToListAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> FiltrarAsync(Expression<Func<TEntity, bool>> filtro, params string[] propiedadesIncluidas)
        {
            IQueryable<TEntity> set = Context.Set<TEntity>().Where(filtro);
            foreach (var prop in propiedadesIncluidas)
                set = set.Include(prop);
            return await set.ToListAsync();
        }
        
    }

}
