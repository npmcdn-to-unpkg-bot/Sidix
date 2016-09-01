using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Concrete
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entidad
    {
        protected readonly IQueryable<TEntity> EntityQuery;
        private readonly DbContext Context; 

        public Repository(DbContext context)
        {
            EntityQuery = context.Set<TEntity>().Where(x => x.Descontinuada == false);
        }
        
        // EN ESTOS METODOS SE VALE USAR LA VARIABLE 'Context' YA QUE SE OCUPA EL DbSet PARA AGREGAR, MODIFICAR, BORRAR ENTRADAS A LA BASE DE DATOS.

        public virtual void Agregar(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public virtual void AgregarRango(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }
        public virtual void Borrar(TEntity entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
        }
        public virtual void BorrarRango(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        // EN LOS SIGUIENTES METODOS, ASEGURARSE DE FILTRAR LAS DESCONTINUADAS USANDO SOLO LA VARIABLE 'EntityQuery'

        public virtual TEntity ObtenerPorId(Expression<Func<TEntity, bool>> idexpression, params string[] propiedadesIncluidas)
        {
            IQueryable<TEntity> query = EntityQuery;
            foreach (var propiedad in propiedadesIncluidas)
            {
                query = query.Include(propiedad);
            }
            return query.SingleOrDefault(idexpression);
        }
        public virtual IEnumerable<TEntity> Obtener(params string[] propiedadesIncluidas)
        {
            IQueryable<TEntity> query = EntityQuery;
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return query.ToList();
        }
        public virtual IEnumerable<TEntity> Filtrar(Expression<Func<TEntity, bool>> filtro, params string[] propiedadesIncluidas)
        {
            IQueryable<TEntity> query = EntityQuery.Where(filtro);
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return query.ToList();
        }

        public virtual async Task<TEntity> ObtenerPorIdAsync(Expression<Func<TEntity, bool>> idexpression, params string[] propiedadesIncluidas)
        {
            IQueryable<TEntity> query = EntityQuery;
            foreach (var propiedad in propiedadesIncluidas)
            {
                query = query.Include(propiedad);
            }
            return await query.SingleOrDefaultAsync(idexpression);
        }
        public virtual async Task<IEnumerable<TEntity>> ObtenerAsync(params string[] propiedadesIncluidas)
        {
            IQueryable<TEntity> query = EntityQuery;
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return await query.ToListAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> FiltrarAsync(Expression<Func<TEntity, bool>> filtro, params string[] propiedadesIncluidas)
        {
            IQueryable<TEntity> query = EntityQuery.Where(filtro);
            foreach (var prop in propiedadesIncluidas)
                query = query.Include(prop);
            return await query.ToListAsync();
        }

        public virtual int Contar()
        {
            return EntityQuery.Count();
        }
        public virtual async Task<int> ContarAsync()
        {
            return await EntityQuery.CountAsync();
        }
        public virtual int Contar(Expression<Func<TEntity, bool>> filtro)
        {
            return EntityQuery.Where(filtro).Count();
        }
        public virtual async Task<int> ContarAsync(Expression<Func<TEntity, bool>> filtro)
        {
            return await EntityQuery.Where(filtro).CountAsync();
        }
        
    }

}
