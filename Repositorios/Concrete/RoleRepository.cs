using System;
using System.Threading.Tasks;
using Dixus.Domain;
using Dixus.Entidades.Identity;
using Dixus.Repositorios.Abstract;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Dixus.Repositorios.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        //public DixusContext DixusContext { get { return Context as DixusContext; } }
        private MyRoleManager _roleManager;
        public RoleRepository(DixusContext context)
        {
            _roleManager = new MyRoleManager(context);
        }
        public RoleRepository() : this(new DixusContext())
        {

        }

        public async Task<IEnumerable<MyRole>> Obtener()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<MyRole> ObtenerPorId(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }
        public async Task<MyRole> ObtenerPorNombre(string nombre)
        {
            return await _roleManager.FindByNameAsync(nombre);
        }

        public async Task<IdentityResult> Crear(MyRole role)
        {
            return await _roleManager.CreateAsync(role);
        }
        public async Task<IdentityResult> Borrar(MyRole role)
        {
            return await _roleManager.DeleteAsync(role);
        }

        public async Task<bool> RoleExists(string nombre)
        {
            return await _roleManager.RoleExistsAsync(nombre);
        }
    }
}
