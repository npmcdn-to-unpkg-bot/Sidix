using Dixus.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Abstract
{
    public interface IRepository<TEntity> where TEntity : Entidad
    {
        void Agregar(TEntity entity);
        void AgregarRango(IEnumerable<TEntity> entities);
        void Borrar(TEntity entity);
        void BorrarRango(IEnumerable<TEntity> entities);
        void Update(TEntity entity);

        IEnumerable<TEntity> Obtener(params string[] propiedadesIncluidas);
        TEntity ObtenerPorId(Expression<Func<TEntity, bool>> idexpression, params string[] propiedadesIncluidas);
        IEnumerable<TEntity> Filtrar(Expression<Func<TEntity, bool>> filtros, params string[] propiedadesIncluidas);

        Task<IEnumerable<TEntity>> ObtenerAsync(params string[] propiedadesIncluidas);
        Task<TEntity> ObtenerPorIdAsync(Expression<Func<TEntity, bool>> idexpression, params string[] propiedadesIncluidas);
        Task<IEnumerable<TEntity>> FiltrarAsync(Expression<Func<TEntity, bool>> filtros, params string[] propiedadesIncluidas);

        int Contar();
        int Contar(Expression<Func<TEntity, bool>> filtro);
        Task<int> ContarAsync();
        Task<int> ContarAsync(Expression<Func<TEntity, bool>> filtro);

    }
}
