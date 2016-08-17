using Dixus.BusinessRules.Inversiones;
using Dixus.BusinessRules.ProyectosDeInversion;
using Dixus.BusinessRules.ProyectosDeInversion.Entidades;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using Dixus.Repositorios.Concrete;
using Dixus.WebUI.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dixus.WebUI.Controllers
{
    public class ProyectosDeInversionController : Controller
    {
        private IUnitOfWork _uow;
        public ProyectosDeInversionController(IUnitOfWork uowParam)
        {
            _uow = uowParam;
        }
        
        public async Task<ActionResult> Ver(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               
            Fraccion fraccion = _uow.Fracciones.ObtenerPorId( fracc => fracc.FraccionId == id.Value, "CalculosEspeciales", "TipoDeSuelo");

            if (fraccion == null)
                return HttpNotFound();

            if (!(fraccion is FraccionVendible))
                return RedirectToAction("Index","home");
            
            ICalculadoraPrecioUnitarioDeInversiones _calculadoraPreciosUnitarios = new CalculadoraPrecioUnitarioDeInversiones(_uow);
            ICalculadoraDeCobroPorInfraestructura _calculadoraCobroInfraestructura = new CalculadoraDeCobroPorInfraestructura(_calculadoraPreciosUnitarios);
            ICalculadoraDeFactoresDeTu _calculadoraFactoresDeTu = new CalculadoraDeFactoresDeTu(_uow.Opciones.Obtener());
            ICalculadoraDeCostosTU _calculadoraDeTU = new CalculadoraDeCostosTUFormaAntigua(_calculadoraCobroInfraestructura, _calculadoraFactoresDeTu);
            ICalculadoraDeProyectosDeInversion _calculadoraProyectosdeInversion = new CalculadoraDeProyectosDeInversion(_calculadoraDeTU);

            InfoCompletaProyectosDeInversion infoDeProyectos = await _calculadoraProyectosdeInversion.CalcularDesgloseYTu((FraccionVendible)fraccion);

            ProyectosInversionViewModel modelo = new ProyectosInversionViewModel()
            {
                Fraccion = fraccion,
                AnalisisTU = infoDeProyectos.TuCompleto,
                AnalisisDePrecioDeVenta = infoDeProyectos.DesgloseFinal
            };

            return View(modelo);
        }

        public ActionResult TablaDeTu(TuMacronanzanaYDesarrollador InfoTu)
        {
            return PartialView(InfoTu);
        }

        //public ActionResult formanueva(int? id)
        //{
        //    if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    Fraccion fraccion = _uow.Fracciones.ObtenerPorId(id.Value);
        //    if (fraccion == null) return HttpNotFound();
        //    if (!(fraccion is FraccionVendible)) return PartialView("Error", "La fracción que intentas analisar no es considerada 'vendible' y por lo tanto no se puede analizar su proyecto de inversiones. Por favor intenta con otra");

        //    Opciones opciones = _uow.Opciones.Obtener();
        //    ICalculadoraPorcentajesDeTu _calculadoraPorcentajesDeTu = new CalculadoraPorcentajesDeTu(opciones);
        //    ICalculadoraDeCostosTU _calculadoraDeCostosTu = new CalculadoraDeCostosTUFormaNueva(_calculadoraPorcentajesDeTu);
        //    ICalculadoraDeProyectosDeInversion _calculadoraProyectosDeInversion = new CalculadoraDeProyectosDeInversion(_calculadoraDeCostosTu.)

        //    ProyectosInversionViewModel modelo = new ProyectosInversionViewModel()
        //    {
        //        Fraccion = fraccion,
        //        //AnalisisTU = _calculadoraProyectosdeInversion.
        //    };

        //    return View(modelo);
        //}
        
    }
}