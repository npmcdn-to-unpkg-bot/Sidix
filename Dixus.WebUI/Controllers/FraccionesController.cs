using System.Diagnostics;
using System.Net;
using System.Web.Mvc;
using Dixus.Repositorios.Abstract;
using Dixus.Entidades;
using Dixus.WebUI.Models;
using AutoMapper;
using System.Data.Entity.Validation;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dixus.WebUI.Controllers
{
    public class FraccionesController : Controller
    {
        private IUnitOfWork uow;
        public FraccionesController(IUnitOfWork uowparam)
        {
            uow = uowparam;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fraccion fraccion = uow.Fracciones.ObtenerPorId(x => x.FraccionId == id, "TipoDeSuelo");
            if (fraccion == null)
            {
                return HttpNotFound();
            }
            return View(fraccion);
        }

        public ActionResult Create()
        {
            CrearFraccionViewModel modelo = new CrearFraccionViewModel();
            ViewBag.TipoDeSueloId = new SelectList(uow.TiposDeSuelo.Obtener(), "TipoDeSueloId", "Nombre", modelo.TipoDeSueloId);
            ViewBag.TipoDeComercioId = new SelectList(uow.TiposDeComercio.Obtener(), "TipoDeComercioId", "Nombre", modelo.TipoDeComercioId ?? null);
            ViewBag.ClienteId = new SelectList(uow.Clientes.Obtener(), "ClienteId", "Nombre", modelo.ClienteId ?? null);
            return View(modelo);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fraccion fraccion = uow.Fracciones.ObtenerPorId(id.Value);
            if (fraccion == null)
            {
                return HttpNotFound();
            }
            return View(fraccion);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fraccion fraccion = uow.Fracciones.ObtenerPorId(id.Value);
            if (fraccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDeSueloId = new SelectList(uow.TiposDeSuelo.Obtener(), "TipoDeSueloId", "Nombre", fraccion.TipoDeSueloId);
            return View(fraccion);
        }
       
        public ActionResult InfoFraccion(Fraccion fraccion, bool? centrada)
        {
            ViewBag.DlCentrado = centrada ?? false;            
            return PartialView(fraccion);
        }

        public async Task<ActionResult> TablaFracciones(IEnumerable<Fraccion> fracciones)
        {
            if (fracciones == null)
            {
                Console.WriteLine("fracciones fue null desde consola");
                Debug.WriteLine("fracciones fue null desde debug");
                fracciones = await uow.Fracciones.ObtenerAsync("TipoDeSuelo","SubdivisionLegal");
            }
            else
            {
                Console.WriteLine("fracciones no fue null desde consola");
                Debug.WriteLine("fracciones no fue null desde debug");
            }

            TablaFraccionesViewModel model = new TablaFraccionesViewModel()
            {
                Fracciones = fracciones
            };

            return PartialView(model);
        }

        public ActionResult RegistrarCompraDeFraccion(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Fraccion fraccion = uow.Fracciones.ObtenerPorId(id.Value);
            if (fraccion == null) return HttpNotFound();

            if (!(fraccion is FraccionVendible)) return RedirectToAction("Error", "Home", new { error = "La fracción que seleccionaste no se puede vender" });

            ViewBag.ClienteId = new SelectList(uow.Clientes.Obtener(), "EmpresaId", "Nombre");

            return View();
            
        }

        [Authorize(Roles = "Tecnico")]
        public ActionResult ObtenerCambiosHechosEnAutocad()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CrearFraccionViewModel fraccionnueva)
        {
            if (ModelState.IsValid)
            {
                if (fraccionnueva.Vendida == false) fraccionnueva.ClienteId = null;
                try {
                    switch (fraccionnueva.TipoDeSueloId){
                        case (int)TiposDeSuelo.ViviendaEconomica: uow.Fracciones.Agregar(Mapper.Map<FraccionViviendaEconomica>(fraccionnueva)); break;
                        case (int)TiposDeSuelo.ViviendaSocial: uow.Fracciones.Agregar(Mapper.Map<FraccionViviendaSocial>(fraccionnueva)); break;
                        case (int)TiposDeSuelo.ViviendaPopular: uow.Fracciones.Agregar(Mapper.Map<FraccionViviendaPopular>(fraccionnueva)); break;
                        case (int)TiposDeSuelo.ViviendaMedia: uow.Fracciones.Agregar(Mapper.Map<FraccionViviendaMedia>(fraccionnueva)); break;
                        case (int)TiposDeSuelo.ViviendaResidencial: uow.Fracciones.Agregar(Mapper.Map<FraccionViviendaResidencial>(fraccionnueva)); break;
                        case (int)TiposDeSuelo.Comercial: uow.Fracciones.Agregar(Mapper.Map<FraccionCOM>(fraccionnueva)); break;
                        case (int)TiposDeSuelo.ComercioYServicios: uow.Fracciones.Agregar(Mapper.Map<FraccionCS>(fraccionnueva)); break;
                        case (int)TiposDeSuelo.Industrial: uow.Fracciones.Agregar(Mapper.Map<FraccionIN>(fraccionnueva)); break;
                        case (int)TiposDeSuelo.ParqueAltaTecnologia: uow.Fracciones.Agregar(Mapper.Map<FraccionPAT>(fraccionnueva)); break;
                        case (int)TiposDeSuelo.ServiciosEspeciales: uow.Fracciones.Agregar(Mapper.Map<FraccionSE>(fraccionnueva)); break;
                        case (int)TiposDeSuelo.AreaConservacion: uow.Fracciones.Agregar(Mapper.Map<FraccionAC>(fraccionnueva)); break;
                        case (int)TiposDeSuelo.ReservaEstrategica: uow.Fracciones.Agregar(Mapper.Map<FraccionRE>(fraccionnueva)); break;
                        case (int)TiposDeSuelo.EquipamentoUrbano: uow.Fracciones.Agregar(Mapper.Map<FraccionEU>(fraccionnueva)); break;
                        case (int)TiposDeSuelo.Donaciones: uow.Fracciones.Agregar(Mapper.Map<FraccionDON>(fraccionnueva)); break;
                        //case 15: uow.Fracciones.Agregar(Mapper.Map<FraccionVIAL>(fraccionnueva)); break;
                        default: return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    uow.SaveToDB();
                    return RedirectToAction("Index");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors){
                        foreach (var validationError in validationErrors.ValidationErrors) {
                            Debug.WriteLine("Property: {0} Error: {1}",  validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                    ViewBag.TipoDeSueloId = new SelectList(uow.TiposDeSuelo.Obtener(), "TipoDeSueloId", "Nombre", fraccionnueva.TipoDeSueloId);
                    ViewBag.TipoDeComercioId = new SelectList(uow.TiposDeComercio.Obtener(), "TipoDeComercioId", "Nombre", fraccionnueva.TipoDeComercioId);
                    ViewBag.ClienteId = new SelectList(uow.Clientes.Obtener(), "ClienteId", "Nombre", fraccionnueva.ClienteId);
                    Debug.WriteLine(ex.Message);
                    return View(fraccionnueva);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return View(fraccionnueva);
                }
            }
            ViewBag.TipoDeSueloId = new SelectList(uow.TiposDeSuelo.Obtener(), "TipoDeSueloId", "Nombre", fraccionnueva.TipoDeSueloId);
            ViewBag.TipoDeComercioId = new SelectList(uow.TiposDeComercio.Obtener(), "TipoDeComercioId", "Nombre", fraccionnueva.TipoDeComercioId);
            ViewBag.ClienteId = new SelectList(uow.Clientes.Obtener(), "ClienteId", "Nombre", fraccionnueva.ClienteId);
            return View(fraccionnueva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarCompraDeFraccion(VenderFraccionViewModel model)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fraccion fraccion)
        {
            ModelState.AddModelError("", "No se ha implementado este proceso");
            ViewBag.TipoDeSueloId = new SelectList(uow.TiposDeSuelo.Obtener(), "TipoDeSueloId", "Nombre", fraccion.TipoDeSueloId);
            return View(fraccion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fraccion fraccion = uow.Fracciones.ObtenerPorId(id);
            uow.Fracciones.Borrar(fraccion);
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
