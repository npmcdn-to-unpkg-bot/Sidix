using Dixus.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Abstract
{

    public interface IRepository<TEntity> : IRepositoryBasic<TEntity> where TEntity : Entidad
    {

        TEntity ObtenerPorId(int id);
        TEntity ObtenerPorId(Expression<Func<TEntity, bool>> idexpression, params string[] propiedadesIncluidas);
        IEnumerable<TEntity> Obtener(params string[] propiedadesIncluidas);
        IEnumerable<TEntity> Filtrar(Expression<Func<TEntity, bool>> filtros, params string[] propiedadesIncluidas);

        Task<TEntity> ObtenerPorIdAsync(int id);
        Task<TEntity> ObtenerPorIdAsync(Expression<Func<TEntity, bool>> idexpression, params string[] propiedadesIncluidas);
        Task<IEnumerable<TEntity>> ObtenerAsync(params string[] propiedadesIncluidas);
        Task<IEnumerable<TEntity>> FiltrarAsync(Expression<Func<TEntity, bool>> filtros, params string[] propiedadesIncluidas);


    }

}
