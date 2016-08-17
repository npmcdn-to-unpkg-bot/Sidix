using Dixus.Entidades.Identity;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Abstract
{
    public interface IUserRepository
    {
        Task<IEnumerable<MyUser>> Obtener(params string[] propiedadesIncluidas);
        Task<MyUser> ObtenerPorId(string id, params string[] propiedadesIncluidas);
        Task<MyUser> ObtenerPorNombreDeUsuario(string username, params string[] propiedadesIncluidas);

        Task<IdentityResult> Crear(MyUser user, string password);
        Task<IdentityResult> Borrar(MyUser user);
        Task<IdentityResult> CambiarContraseña(string userid, string contraseñaAnterior, string contraseñaNueva);

        Task<IdentityResult> AñadirARole(string userid, string role);
        Task<IdentityResult> AñadirARoles(string userid, params string[] roles);
        Task<IdentityResult> QuitarDeRole(string userid, string role);
        Task<IdentityResult> QuitarDeRoles(string userid, params string[] roles);
        Task<bool> UsuarioEstaEnRole(string userid, string role);
        Task<IEnumerable<string>> ObtenerRolesDeUsuario(string userid);

        Task<IdentityResult> AsignarEmail(string userid, string email);
        Task EnviarEmail(string userid, string subject, string body);

        Task<ClaimsIdentity> Login(string username, string password);

        

    }
}
