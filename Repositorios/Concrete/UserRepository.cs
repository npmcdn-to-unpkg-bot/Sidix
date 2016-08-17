using System;
using Dixus.Domain;
using Dixus.Entidades.Identity;
using Dixus.Repositorios.Abstract;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Dixus.Repositorios.Concrete
{
    public class UserRepository : IUserRepository
    {
        private MyUserManager _userManager;
        private DixusContext _context;
        public UserRepository(DixusContext context)
        {
            _context = context;
            _userManager = new MyUserManager(context);
        }
        public UserRepository() : this(new DixusContext())
        {

        }
       
        public async Task<IEnumerable<MyUser>> Obtener(params string[] propiedadesIncluidas)
        {
            IQueryable<MyUser> users = _userManager.Users;
            foreach (var prop in propiedadesIncluidas)
                users = users.Include(prop);
            return await users.ToListAsync();
        }
        public async Task<MyUser> ObtenerPorId(string id, params string[] propiedadesIncluidas)
        {
            IQueryable<MyUser> users = _userManager.Users;
            foreach (var prop in propiedadesIncluidas)
                users = users.Include(prop);
            return await users.SingleOrDefaultAsync(user => user.Id == id);
        }
        public async Task<MyUser> ObtenerPorNombreDeUsuario(string username, params string[] propiedadesIncluidas)
        {
            IQueryable<MyUser> users = _userManager.Users;
            foreach (var prop in propiedadesIncluidas)
                users = users.Include(prop);
            return await users.SingleOrDefaultAsync(user => user.UserName == username);
        }
        
        public async Task<IdentityResult> Crear(MyUser user, string password)
        {
            if (_userManager.FindByName(user.UserName) != null)
                throw new Exception("Un usuario con el nombre " + user.UserName + " ya existe.");

            return await _userManager.CreateAsync(user, password);
        }
        public async Task<IdentityResult> Borrar(MyUser user)
        {
            return await _userManager.DeleteAsync(user);
        }
        public async Task<IdentityResult> CambiarContraseña(string userid, string contraseñaAnterior, string contraseñaNueva)
        {
            return await _userManager.ChangePasswordAsync(userid, contraseñaAnterior, contraseñaNueva);
        }

        public async Task<IdentityResult> AñadirARole(string userid, string role)
        {
            return await _userManager.AddToRoleAsync(userid, role);
        }
        public async Task<IdentityResult> AñadirARoles(string userid, params string[] roles)
        {
            return await _userManager.AddToRolesAsync(userid, roles);
        }
        public async Task<IdentityResult> QuitarDeRole(string userid, string role)
        {
            return await _userManager.RemoveFromRoleAsync(userid, role);
        }
        public async Task<IdentityResult> QuitarDeRoles(string userid, params string[] roles)
        {
            return await _userManager.RemoveFromRolesAsync(userid, roles);
        }
        public async Task<bool> UsuarioEstaEnRole(string userid, string role)
        {
            return await _userManager.IsInRoleAsync(userid, role);
        }
        public async Task<IEnumerable<string>> ObtenerRolesDeUsuario(string userid)
        {
            return await _userManager.GetRolesAsync(userid);
        }

        public async Task<IdentityResult> AsignarEmail(string userid, string email)
        {
            return await _userManager.SetEmailAsync(userid, email);
        }
        public async Task EnviarEmail(string userid, string subject, string body)
        {
            await _userManager.SendEmailAsync(userid, subject, body);
        }

        public async Task<ClaimsIdentity> Login(string username, string password)
        {
            
            var user = await _userManager.FindByNameAsync(username);
            var user2 = await _userManager.FindAsync(username, password);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, password))
                {
                    return await _userManager.CreateIdentityAsync(user, "Cookie");
                }
            }
            throw new Exception("El usuario o contraseña son inválidos");

        }
    }
}
