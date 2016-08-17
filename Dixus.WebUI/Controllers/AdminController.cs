using System.Web.Mvc;
using Dixus.WebUI.Models;
using Dixus.Entidades.Identity;
using Dixus.Entidades;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using Dixus.Repositorios.Abstract;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNet.Identity;

namespace Dixus.WebUI.Controllers
{

    [Authorize(Roles = "Administrador")]
    public class AdminController : Controller
    {
        private IUnitOfWork uow;
        const int MaxNumDeEtapasDisponibles = 5;
        public AdminController(IUnitOfWork uowparam)
        {
            uow = uowparam;
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Opciones()
        {
            AdminOpcionesViewModel model = Mapper.Map<AdminOpcionesViewModel>(uow.Opciones.Obtener());
            ViewBag.NumeroDeEtapas = GenerarDropdownDeEtapas(model.NumeroDeEtapas);
            return View(model);
        }

        public async Task<ActionResult> Usuarios()
        {
            var usuarios = Mapper.Map<IEnumerable<UsuariosConRol>>(await uow.Usuarios.Obtener());
            foreach(var user in usuarios)
            {
                user.Roles = await uow.Usuarios.ObtenerRolesDeUsuario(user.Id);
            }
            usuarios = usuarios.OrderByDescending(u => u.Roles.Count());
            AdminUsuariosViewModel model = new AdminUsuariosViewModel()
            {
                usuarios = usuarios
            };
            return View(model);
        }

        public ActionResult Procesos(int? NumDeJuntas, int? NumDeTareas, int? NumDeAcuerdos)
        {
            ConcentradoOperacionViewModel model = new ConcentradoOperacionViewModel()
            {
                Juntas = NumDeJuntas.HasValue ? uow.Juntas.ObtenerJuntasMasRecientes(NumDeJuntas.Value) : uow.Juntas.Obtener("UsuariosPresentes"),
                Acuerdos = NumDeAcuerdos.HasValue ? uow.Acuerdos.ObtenerAcuerdosMasRecientes(NumDeAcuerdos.Value) : uow.Acuerdos.Obtener(),
                Tareas = NumDeTareas.HasValue ? uow.Tareas.ObtenerTareasMasRecientes<Tarea>(NumDeTareas.Value) : uow.Tareas.Obtener()
            };
            return View(model);
        }

        public async Task<ActionResult> AgregarUsuario()
        {
            var roles = await uow.Roles.Obtener();
            ViewBag.RoleId = new SelectList(roles, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AgregarUsuario(AgregarUsuarioViewModel model)
        {
            if (ModelState.IsValid) {
                MyUser user = CrearInstanciaDeUsuario(model.UserName, model.Nombre, model.Apellidos, model.Puesto, model.Email);
                string[] rolesSeleccionados = TransformarRolesAListaDeString(model.Roles);
                try
                {
                    var crearUsuario = await uow.Usuarios.Crear(user, model.Password);
                    if (crearUsuario.Succeeded)
                    {
                        var anadirARoles = await uow.Usuarios.AñadirARoles(user.Id, rolesSeleccionados);
                        if (anadirARoles.Succeeded)
                            return RedirectToAction("Index", "Admin");
                        else
                            ModelState.AddModelError("", String.Format("Se creo el usuario {0}, pero no se pudo anadir a los siguientes roles: {1}",user.UserName, string.Join(", ", rolesSeleccionados)));
                    }
                    else
                    {
                        ModelState.AddModelError("", String.Format("No se pudo crear el usuario {0}",user.UserName));
                    }
                    
                }
                catch (System.Exception ex){
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Opciones(AdminOpcionesViewModel opciones)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    uow.Opciones.Update(Mapper.Map<Opciones>(opciones));
                    uow.SaveToDB();
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError("", "Hubo un error actualizando las opciones del sistema: "+ex.Message);
                }
            }
            ViewBag.NumeroDeEtapas = GenerarDropdownDeEtapas(opciones.NumeroDeEtapas);
            return View(opciones);
        }

       


        // HELPER METHODS
        private MyUser CrearInstanciaDeUsuario(string userName, string nombre, string apellidos, string puesto, string email)
        {
            return new MyUser()
            {
                UserName = userName,
                Nombre = nombre,
                Apellido = apellidos,
                Puesto = puesto,
                Email = email,
                Id = Guid.NewGuid().ToString()
            };
        }

        private string[] TransformarRolesAListaDeString(RolesDeUsuario roles)
        {
            List<string> rolesSeleccionados = new List<string>();
            if (roles.EsAdministrador) rolesSeleccionados.Add("Administrador");
            if (roles.EsTecnico) rolesSeleccionados.Add("Técnico");
            if (roles.EsLegal) rolesSeleccionados.Add("Legal");
            if (roles.EsVentas) rolesSeleccionados.Add("Ventas");
            return rolesSeleccionados.ToArray();
        }

        private List<SelectListItem> GenerarDropdownDeEtapas(int etapaSeleccionadaActualmente)
        {
            List<SelectListItem> dropdownEtapas = new List<SelectListItem>();
            for (int i = 1; i < MaxNumDeEtapasDisponibles; i++)
            {
                dropdownEtapas.Add(new SelectListItem()
                {
                    Value = i.ToString(),
                    Text = i.ToString(),
                    Selected = (i == etapaSeleccionadaActualmente) ? true : false
                });
            }
            return dropdownEtapas;
        }

    //[HttpPost]
        //public async Task<ActionResult> EditarUsuario([Bind(Exclude = "UserName" )] AgregarUsuarioViewModel usuario)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    else
        //    {
        //        return View(usuario);
        //    }
        //}

        //public async Task<ActionResult> EditarUsuario(string id)
        //{
        //    if (String.IsNullOrEmpty(id)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    MyUser usuario = await uow.Usuarios.ObtenerPorId(id);
        //    if (usuario == null) return HttpNotFound();
        //}

    }
}