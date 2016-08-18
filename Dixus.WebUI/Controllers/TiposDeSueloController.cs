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
    public class TiposDeSueloController : Controller
    {
        private IUnitOfWork uow;
        public TiposDeSueloController(IUnitOfWork uowparam)
        {
            uow = uowparam;
        }

        public ActionResult Index()
        {
            return View(uow.TiposDeSuelo.Obtener("Fracciones"));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeSuelo tipoDeSuelo = uow.TiposDeSuelo.ObtenerPorId( tipo => tipo.TipoDeSueloId == id.Value, "Fracciones");
            if (tipoDeSuelo == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeSuelo);
        }

     
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeSuelo tipoDeSuelo = uow.TiposDeSuelo.ObtenerPorId(id.Value);
            if (tipoDeSuelo == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeSuelo);
        }
        
        public JsonResult JsonTiposDeSuelo()
        {
            var tipos = uow.TiposDeSuelo.Obtener().Select(tipo => new
            {
                Nombre = tipo.Nombre,
                UsoId = tipo.TipoDeSueloId
            });
            return Json(tipos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoDeSueloId,Nombre,Color,MvaPorHectarea")] TipoDeSuelo tipoDeSuelo)
        {
            if (ModelState.IsValid)
            {
                uow.TiposDeSuelo.Update(tipoDeSuelo);
                uow.SaveToDB();
                return RedirectToAction("Index");
            }
            return View(tipoDeSuelo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id > 0 && id <= 15)
            {
                return View("NoSePuedeBorrar");
            }
            TipoDeSuelo tipoDeSuelo = uow.TiposDeSuelo.ObtenerPorId(id);
            uow.TiposDeSuelo.Borrar(tipoDeSuelo);
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
