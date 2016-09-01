using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Dixus.WebUI.Controllers
{
    public class EscriturasController : Controller
    {
        IUnitOfWork uow;
        public EscriturasController(IUnitOfWork uowparam)
        {
            uow = uowparam;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Subdivision(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            EscrituraDeSubdivision escritura = uow.EscriturasDeSubdivision.ObtenerPorId( esc => esc.EscrituraId == id.Value);
            if (escritura == null) return HttpNotFound();
            
            return View(escritura);
        }

        public ActionResult Traspaso(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            EscrituraDeTraspaso escritura = uow.EscriturasDeTraspaso.ObtenerPorId( esc => esc.EscrituraId == id.Value );
            if (escritura == null) return HttpNotFound();
            
            return View(escritura);
        }

        //public ActionResult PDF(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Escritura escritura = uow.Escrituras.ObtenerPorId(id.Value);
        //    if (escritura == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return File(escritura.Pdf);
        //}
    }

    public class ArchivoPdf : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}