using Dixus.Repositorios.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dixus.WebUI.Controllers
{
    public class FinanzasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FinanzasController(IUnitOfWork uowParam)
        {
            _unitOfWork = uowParam;
        }

        // GET: Finanzas
        public ActionResult Index()
        {
            return View();
        }
    }
}