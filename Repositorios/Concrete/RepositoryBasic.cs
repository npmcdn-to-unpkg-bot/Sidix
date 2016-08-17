using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Concrete
{
    public abstract class RepositoryBasic<TEntity> : IRepositoryBasic<TEntity> where TEntity : Entidad
    {
        private readonly DbContext Context;
        public RepositoryBasic(DbContext context)
        {
            Context = context;
        }

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

        public virtual int Contar()
        {
            return Context.Set<TEntity>().Count();
        }
        public virtual async Task<int> ContarAsync()
        {
            return await Context.Set<TEntity>().CountAsync();
        }

    }

}
