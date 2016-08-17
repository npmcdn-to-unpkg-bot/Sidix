using Dixus.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Abstract
{
    public interface IRepositoryBasic<TEntity> where TEntity : Entidad
    {
        void Agregar(TEntity entity);
        void AgregarRango(IEnumerable<TEntity> entities);
        void Borrar(TEntity entity);
        void BorrarRango(IEnumerable<TEntity> entities);
        void Update(TEntity entity);

        int Contar();
        Task<int> ContarAsync();


    }
}
