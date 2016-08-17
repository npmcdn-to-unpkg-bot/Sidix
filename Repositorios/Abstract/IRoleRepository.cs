using Dixus.Entidades.Identity;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Dixus.Repositorios.Abstract
{
    public interface IRoleRepository 
    {
        Task<IEnumerable<MyRole>> Obtener();
        Task<MyRole> ObtenerPorNombre(string nombre);
        Task<MyRole> ObtenerPorId(string id);
        Task<IdentityResult> Crear(MyRole role);
        Task<IdentityResult> Borrar(MyRole role);
        Task<bool> RoleExists(string nombre);

    }
}
