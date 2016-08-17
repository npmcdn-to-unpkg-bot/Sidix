using System.Web.Mvc;
using Dixus.Repositorios.Abstract;
using Dixus.WebUI.Models;
using System.Linq;
using System.Collections.Generic;
using Dixus.Entidades;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Threading;

namespace Dixus.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork unitOfWork;
        public HomeController(IUnitOfWork uowParam)
        {
            unitOfWork = uowParam;
        }

        public ActionResult Index()
        {
            var fracciones = unitOfWork.Fracciones.Obtener();
            
            ViewBag.EmpresasDropdown = new SelectList(
                unitOfWork.Clientes.Obtener()
                .Select(x => new { Nombre = x.Nombre, ID = x.ClienteId })
                .OrderBy(x => x.Nombre),
                "ID", "Nombre"
            );

            ViewBag.FraccionesVendiblesDropdown = new SelectList(
                fracciones.OfType<FraccionVendible>()
                .Select(x => new { Nombre = x.Nombre, ID = x.FraccionId })
                .OrderBy(x=>x.Nombre),
                "ID","Nombre"
            );

            ViewBag.FraccionesDropdown = new SelectList(
                fracciones
                .Select(fracc => new { Nombre = fracc.Nombre, ID = fracc.FraccionId})
                .OrderBy(fracc => fracc.Nombre),
                "ID","Nombre"       
            );

            ViewBag.SubdivisionesDropdown = new SelectList(
                unitOfWork.SubdivisionesLegales.Obtener()
                .Select(fracc => new { Nombre = fracc.Nombre, ID = fracc.FraccionLegalId })
                .OrderBy(fracc => fracc.Nombre),
                "ID", "Nombre"
            );

            ViewBag.TiposDeSueloDropdown = new SelectList(
                unitOfWork.TiposDeSuelo.Obtener()
                .Select(suelo => new { Nombre = suelo.Nombre, ID = suelo.TipoDeSueloId } ),
                "ID","Nombre"
            );

            return View(new HomeViewModel());
        }

        public ActionResult Dashboard()
        {
             return View();
        }
    }

}