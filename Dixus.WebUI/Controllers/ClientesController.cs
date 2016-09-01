using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;

namespace Dixus.WebUI.Controllers
{
    public class ClientesController : Controller
    {
        private IUnitOfWork uow;
        public ClientesController(IUnitOfWork uowparam)
        {
            uow = uowparam;
        }

        public ActionResult Index()
        {
            var clientes = uow.Clientes.Obtener("Subdivisiones.FraccionesPlanMaestro");
            return View(clientes);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = uow.Clientes.ObtenerPorId( cli => cli.ClienteId == id.Value, "Subdivisiones.FraccionesPlanMaestro.TipoDeSuelo");
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId,Nombre")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                uow.Clientes.Agregar(cliente);
                uow.SaveToDB();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = uow.Clientes.ObtenerPorId( cli => cli.ClienteId == id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId,Nombre")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                uow.Clientes.Update(cliente);
                uow.SaveToDB();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = uow.Clientes.ObtenerPorId( cli => cli.ClienteId == id );
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = uow.Clientes.ObtenerPorId( cli => cli.ClienteId == id );
            uow.Clientes.Borrar(cliente);
            uow.SaveToDB();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
