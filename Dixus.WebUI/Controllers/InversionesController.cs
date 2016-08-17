using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dixus.WebUI.Models;
using Dixus.BusinessRules.Inversiones.Entidades;
using Dixus.BusinessRules.Inversiones;
using System.Threading.Tasks;

namespace Dixus.WebUI.Controllers
{
    public class InversionesController : Controller
    {
        private IUnitOfWork _uow;
        public InversionesController(IUnitOfWork uowParam)
        {
            _uow = uowParam;
        }

        public async Task<ActionResult> Index()
        {
            InversionesIndexModel model = new InversionesIndexModel();
            ICalculadoraPrecioUnitarioDeInversiones CalculadoraPU = new CalculadoraPrecioUnitarioDeInversiones(_uow);
            
            await _uow.Transacciones.ObtenerInversiones()
                .ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    ConcentradoDeInversiones concentrado = new ConcentradoDeInversiones();
                    var inversiones = task.Result;

                    concentrado.InversionEnEnergia = inversiones.OfType<InversionElectricidad>().Sum(inv => inv.Monto);
                    concentrado.InversionEnAguaPotable = inversiones.OfType<InversionAguaPotable>().Sum(inv => inv.Monto);
                    concentrado.InversionEnSaneamiento = inversiones.OfType<InversionSaneamiento>().Sum(inv => inv.Monto);
                    concentrado.InversionEnVialidades = inversiones.OfType<InversionVialidades>().Sum(inv => inv.Monto);
                    concentrado.InversionEnRedDigital = inversiones.OfType<InversionRedDigital>().Sum(inv => inv.Monto);
                    concentrado.InversionEnGasNatural = inversiones.OfType<InversionGasNatural>().Sum(inv => inv.Monto);
                    concentrado.InversionEnMovimientoDeTierra = inversiones.OfType<InversionMovimientoTierra>().Sum(inv => inv.Monto);
                    concentrado.InversionEnObrasEspeciales = inversiones.OfType<InversionObrasEspeciales>().Sum(inv => inv.Monto);

                    concentrado.InversionEnEstudiosYProyectos = inversiones.OfType<InversionEstudiosYProyectos>().Sum(inv => inv.Monto);
                    concentrado.InversionEnPostVenta = inversiones.OfType<InversionPostVenta>().Sum(inv => inv.Monto);
                    concentrado.InversionEnCostosIndirectosDeObra = inversiones.OfType<InversionCostosIndirectosObra>().Sum(inv => inv.Monto);

                    return concentrado;
                }
                else
                {
                    throw new Exception("Hubo un error al tratar de acceder a las inversiones");
                }
            })
                .ContinueWith(task =>
            {
                model.TotalesDeInversiones = task.Result;
            });

            await CalculadoraPU.CalcularTodosLosPreciosUnitarios()
                .ContinueWith(task =>
                {
                    if (task.Status == TaskStatus.RanToCompletion)
                        model.PreciosUnitariosPorTipoDeInversion = task.Result;
                    else
                        throw new Exception("Hubo un error al cargar los costos unitarios de inversiones. El estatus del request es: "+task.Status);
                });

            return View(model);
        }

        public ActionResult EnergiaElectrica()
        {
            IEnumerable<Fraccion> fracciones = _uow.Fracciones.Obtener();
            EnergiaElectricaViewModel model = new EnergiaElectricaViewModel()
            {
                TotalDeMvasDisponibles = _uow.Transacciones.GetMVAsTotal().Result,

                TOtalDeMvasUsados = fracciones.Sum(fracc => fracc.GetMvaRequeridos()),

                MVasPorAreasDeConservacion = fracciones.OfType<FraccionAC>().Sum(fracc => fracc.GetMvaRequeridos()),
                MVasPorComerciales = fracciones.OfType<FraccionCOM>().Sum(fracc => fracc.GetMvaRequeridos()),
                MVasPorComercioYServicios = fracciones.OfType<FraccionCS>().Sum(fracc => fracc.GetMvaRequeridos()),
                MVasPorDonaciones = fracciones.OfType<FraccionDON>().Sum(fracc => fracc.GetMvaRequeridos()),
                MVasPorServiciosEspeciales = fracciones.OfType<FraccionSE>().Sum(fracc => fracc.GetMvaRequeridos()),
                MVasPorEquipamiento = fracciones.OfType<FraccionEU>().Sum(fracc => fracc.GetMvaRequeridos()),
                MVasPorIndustrial = fracciones.OfType<FraccionIN>().Sum(fracc => fracc.GetMvaRequeridos()),
                MVasPorParqueTecnologico = fracciones.OfType<FraccionPAT>().Sum(fracc => fracc.GetMvaRequeridos()),
                MVasPorReservaEstrategica = fracciones.OfType<FraccionRE>().Sum(fracc => fracc.GetMvaRequeridos()),
                //MVasPorVialidades = fracciones.OfType<FraccionVIAL>().Sum(fracc => fracc.GetMvaRequeridos()),
                MVasPorViviendaEconomica = fracciones.OfType<FraccionViviendaEconomica>().Sum(fracc => fracc.GetMvaRequeridos()),
                MVasPorViviendaMedia = fracciones.OfType<FraccionViviendaMedia>().Sum(fracc => fracc.GetMvaRequeridos()),
                MVasPorViviendaPopular = fracciones.OfType<FraccionViviendaPopular>().Sum(fracc => fracc.GetMvaRequeridos()),
                MVasPorViviendaResidencial = fracciones.OfType<FraccionViviendaResidencial>().Sum(fracc => fracc.GetMvaRequeridos()),
                MVasPorViviendaSocial = fracciones.OfType<FraccionViviendaSocial>().Sum(fracc => fracc.GetMvaRequeridos()),

            };
            return View(model);
        }

        public ActionResult AguaPotable()
        {
            return View();
        }

        public ActionResult Saneamiento()
        {
            return View();
        }

        public ActionResult Vialidades()
        {
            return View();
        }

        public ActionResult RedDigital()
        {
            return View();
        }

        public ActionResult GasNatural()
        {
            return View();
        }

        public ActionResult MovimientoDeTierra()
        {
            return View();
        }
        public ActionResult ObrasEspeciales()
        {
            return View();
        }

        public ActionResult EstudiosYProyectos()
        {
            return View();
        }
        public ActionResult PostVenta()
        {
            return View();
        }

        public ActionResult CostosIndirectosDeObra()
        {
            return View();
        }
    }
}