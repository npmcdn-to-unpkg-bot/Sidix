using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dixus.Repositorios.Abstract;
using Dixus.Entidades;

namespace Dixus.WebUI.Controllers
{
    public class TiposDeComercioController : Controller
    {
        private IUnitOfWork uow;
        public TiposDeComercioController(IUnitOfWork uowparam)
        {
            uow = uowparam;
        }

        public ActionResult Index()
        {
            return View(uow.TiposDeComercio.Obtener());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeComercio tipoDeComercio = uow.TiposDeComercio.ObtenerPorId(id.Value);
            if (tipoDeComercio == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeComercio);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoDeComercioId,Nombre")] TipoDeComercio tipoDeComercio)
        {
            if (ModelState.IsValid)
            {
                uow.TiposDeComercio.Agregar(tipoDeComercio);
                uow.SaveToDB();
                return RedirectToAction("Index");
            }

            return View(tipoDeComercio);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeComercio tipoDeComercio = uow.TiposDeComercio.ObtenerPorId(id.Value);
            if (tipoDeComercio == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeComercio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoDeComercioId,Nombre")] TipoDeComercio tipoDeComercio)
        {
            if (ModelState.IsValid)
            {
                uow.TiposDeComercio.Update(tipoDeComercio);
                uow.SaveToDB();
                return RedirectToAction("Index");
            }
            return View(tipoDeComercio);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeComercio tipoDeComercio = uow.TiposDeComercio.ObtenerPorId(id.Value);
            if (tipoDeComercio == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeComercio);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeComercio tipoDeComercio = uow.TiposDeComercio.ObtenerPorId(id);
            uow.TiposDeComercio.Borrar(tipoDeComercio);
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
