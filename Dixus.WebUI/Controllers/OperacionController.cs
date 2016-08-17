using Dixus.Entidades;
using Dixus.Entidades.Identity;
using Dixus.Repositorios.Abstract;
using Dixus.WebUI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Dixus.WebUI.Controllers
{
    public class OperacionController : Controller
    {
        //private string _userId;
        private IUnitOfWork _uow;
        public OperacionController(IUnitOfWork uowParam)
        {
            _uow = uowParam;
            //_userId = HttpContext.User.Identity.GetUserId();
        }

        public ActionResult Tarea(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Tarea tarea = _uow.Tareas.ObtenerPorId ( x=> x.TareaId == id.Value, "JuntaDeConsejo", "Responsables");
            if (tarea == null)
                return HttpNotFound();

            TareaViewModel model = new TareaViewModel() { Tarea = tarea };

            // Para ver los detalles de una tarea, tienes que ser uno de los responsables de cumplirla, o ser administrador
            if ( HttpContext.User.IsInRole("Administrador") || tarea.Responsables.Any( usuario => usuario.Id == HttpContext.User.Identity.GetUserId()))
            {
                return View(tarea);
            }
            else
            {
                return View("Error", new ErrorViewModel(HttpStatusCode.Forbidden));
            }
        }
        public ActionResult AgregarTarea()
        {
            return View();
        }
       
        public async Task<ActionResult> Usuario(string id)
        {
            if (String.IsNullOrEmpty(id)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // Para ver los detalles de un usuario, tienes que ser o el mismo usuario, o administrador
            if (HttpContext.User.IsInRole("Administrador") || HttpContext.User.Identity.GetUserId() == id)
            {
                MyUser usuario = await _uow.Usuarios.ObtenerPorId(id, "Tareas.JuntaDeConsejo", "JuntasAsistidas");
                if (usuario == null) return HttpNotFound();

                List<string> rolesDelUsuario = new List<string>();
                foreach (var role in usuario.Roles)
                {
                    var rol = await _uow.Roles.ObtenerPorId(role.RoleId);
                    rolesDelUsuario.Add(rol.Name);
                }

                SingleUserViewModel model = new SingleUserViewModel()
                {
                    Usuario = usuario,
                    Roles = rolesDelUsuario
                };

                return View(model);
            }
            else
            {
                return View("Error", new ErrorViewModel(HttpStatusCode.Forbidden));
            }
        }

        public ActionResult Junta(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            JuntaDeConsejo junta = _uow.Juntas.ObtenerPorId( j => j.JuntaDeConsejoId == id.Value, "Acuerdos", "Tareas", "UsuariosPresentes");
            if (junta == null) return HttpNotFound();

            JuntaViewModel model = new JuntaViewModel() { Junta = junta };

            // Para ver los detalles de una junta, tienes que haber estado presente, o ser administrador
            if (HttpContext.User.IsInRole("Administrador") || junta.UsuariosPresentes.Any(us => us.Id == HttpContext.User.Identity.GetUserId()))
            {
                return View(model);
            }
            else
            {
                return View("Error", new ErrorViewModel(HttpStatusCode.Forbidden));
            }
        }
        public ActionResult AgregarJunta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarTarea(NuevaTareaViewModel model)
        {
            if (ModelState.IsValid)
            {
                // To do: agregar tarea
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult AgregarJunta(NuevaJuntaViewModel model)
        {
            if (ModelState.IsValid)
            {
                // To do: agregar junta
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }
    }
}