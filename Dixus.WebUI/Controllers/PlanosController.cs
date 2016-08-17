using AutoMapper;
using Dixus.BusinessRules.CambiosAutocad.Abstract;
using Dixus.BusinessRules.CambiosAutocad.Concrete;
using Dixus.BusinessRules.CambiosAutocad.Entidades;
using Dixus.BusinessRules.Fracciones.Abstract;
using Dixus.BusinessRules.Fracciones.Concrete;
using Dixus.Entidades;
using Dixus.Entidades.Gis;
using Dixus.Repositorios.Abstract;
using Dixus.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dixus.WebUI.Controllers
{
    public class PlanosController : Controller
    {
        private IUnitOfWork _uow;
        public PlanosController(IUnitOfWork uowParam)
        {
            _uow = uowParam;
        }

        public ActionResult Leaflet()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Satelite()
        {
           
            return View();
        }

        public ActionResult Anza()
        {
            return View();
        }

        public ActionResult Mapbox()
        {
            return View();
        }
        
        [Authorize(Roles = "Técnico")]
        public ActionResult ChecarSiHayCambios()
        {
            IEnumerable<Fraccion> FraccionesSidix = _uow.Fracciones.Obtener(); 
            IEnumerable<FeatureFraccion> FraccionesAutocad = _uow.Gis.ObtenerFracciones(); 
            IEnumerable<VialPoly> VialidadesAutocad = _uow.Gis.ObtenerPoligonosVialidades();
            IEnumerable<Vialidad> VialidadeSidix = _uow.Vialidades.Obtener();
            
            IDetectorDeCambiosAutocad detectorDeCambios = new DetectorDeCambiosAutocad(
                fraccionesActuales: FraccionesSidix,
                fraccionesNuevas: FraccionesAutocad,
                vialidadesActuales: VialidadeSidix,
                vialidadesNuevas: VialidadesAutocad);

            bool haCambiado = detectorDeCambios.ChecarSiModeloHaCambiado();

            return PartialView(haCambiado);

        }

        [Authorize(Roles = "Técnico")]
        public async Task<ActionResult> ConfirmarCambios()
        {
            IDetectorDeCambiosAutocad detectorDeCambios = await ObtenerDetectorDeCambios();
            IValidadorAutocad validador = new ValidadorAutocad(detectorDeCambios.ObtenerSetDeFraccionesNuevas(), detectorDeCambios.ObtenerSetDeVialidadesNuevas());

            OpcionesDeValidacionAutocad opcionesDeValidacion = Mapper.Map<OpcionesDeValidacionAutocad>(_uow.Opciones.Obtener());
            bool esValido = await validador.ChecarSiModeloAutocadEsValido(opcionesDeValidacion);

            if ( esValido)
            {
                ResumenDeCambiosAutocad resumen = await detectorDeCambios.ObtenerResumenDeCambios();
                bool fraccionesAModificarSonModificables = await validador.TodasLasFraccionesQueCambiaranSonModificables(resumen.FraccionesSidixQueNoTienenContraparte);

                if (fraccionesAModificarSonModificables)
                {
                    //Session["ResumenValidadoDeCambiosAutocad"] = resumen;
                    return View(resumen);
                }
                else
                {
                    ErroresDeValidacionViewModel modeloValidacion = new ErroresDeValidacionViewModel()
                    {
                        FraccionesModificadasQueNoSeDebenModificar = await validador.ObtenerFraccionesQueCambiaranQueSonInmodificables(resumen.FraccionesSidixQueNoTienenContraparte)
                    };
                    return View("ErroresDeValidacion", modeloValidacion);
                }
            }
            else
            {
                ErroresDeValidacionViewModel modeloValidacion = new ErroresDeValidacionViewModel();

                if (opcionesDeValidacion.ValidarQuePoligonosNoSeSobrepongan)
                    modeloValidacion.GeometriasSobrepuestas = await validador.ObtenerAreasSobrepuestas(opcionesDeValidacion.TamañoMaximoDeSobreposiciones);

                if (opcionesDeValidacion.ValidarQuePoligonosEstenCerrados)
                    modeloValidacion.PoligonosNoCerrados = await validador.ObtenerPoligonosNoCerrados();

                if (opcionesDeValidacion.ValidarQuePoligonosSeanValidos)
                    modeloValidacion.PoligonosInvalidos = await validador.ObtenerPoligonosInvalidos();

                if (opcionesDeValidacion.ValidarQueTodasLasGeometriasSeanPoligonos)
                    modeloValidacion.GeometriasQueNoSonPoligonos = await validador.ObtenerGeometriasQueNoSonPoligonos();

                if (opcionesDeValidacion.ValidarSuperficieTotal)
                    modeloValidacion.SumaTotalEsValida = await validador.AutocadTieneSuperficieValida(opcionesDeValidacion.AreaTotalDelProyectoEnMetros, opcionesDeValidacion.ToleranciaEnM2ParaProyecto);

                return View("ErroresDeValidacion", modeloValidacion);
            }
        }

        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Técnico")]
        [HttpPost, ActionName("ConfirmarCambios")]
        public async Task<ActionResult> ConfimarCambiosHechos()
        {
            //if ( Session["ResumenValidadoDeCambiosAutocad"] != null && Session["ResumenValidadoDeCambiosAutocad"] is ResumenDeCambiosAutocad)
            //{
            IDetectorDeCambiosAutocad detectorDeCambios = await ObtenerDetectorDeCambios();
            var resumen = await detectorDeCambios.ObtenerResumenDeCambios();
            //var resumen = (ResumenDeCambiosAutocad)Session["ResumenValidadoDeCambiosAutocad"];
            IFraccionFactory factory = new FraccionFactory();
                
                // FRACCIONES
                foreach( var pareja in resumen.ObtenerFraccionesQueNomasModificaronNombre())
                {
                    string nuevoNombre = pareja.FraccionAutocad.Nombre;
                    pareja.FraccionSidix.Nombre = nuevoNombre;
                    _uow.Fracciones.Update(pareja.FraccionSidix);
                }

                foreach( var pareja in resumen.ObtenerFraccionesQueNomasModificaronUsoDeSuelo())
                {
                    int nuevoUsoDeSueloId = pareja.FraccionAutocad.ObtenerUsoDeSueloId();
                    Fraccion fraccSiendoCambiada = pareja.FraccionSidix;
                    Fraccion fraccConNuevoUsoDeSuelo = factory.ConvertirFraccionAOtroUsoDeSuelo(fraccSiendoCambiada, nuevoUsoDeSueloId);

                    _uow.Fracciones.Borrar(fraccSiendoCambiada);
                    _uow.Fracciones.Agregar(fraccConNuevoUsoDeSuelo);
                }

                foreach ( var pareja in resumen.ObtenerFraccionesQueModificaronNombreYUso())
                {
                    int nuevoUsoDeSueloId = pareja.FraccionAutocad.ObtenerUsoDeSueloId();
                    string nuevoNombre = pareja.FraccionAutocad.Nombre;
                    Fraccion fraccSiendoCambiada = pareja.FraccionSidix;
                    fraccSiendoCambiada.Nombre = nuevoNombre;
                    Fraccion fraccConNuevoUsoDeSuelo = factory.ConvertirFraccionAOtroUsoDeSuelo(fraccSiendoCambiada, nuevoUsoDeSueloId);

                    _uow.Fracciones.Borrar(fraccSiendoCambiada);
                    _uow.Fracciones.Agregar(fraccConNuevoUsoDeSuelo);
                }

                foreach( var fraccSidixSinContraparte in resumen.FraccionesSidixQueNoTienenContraparte)
                {
                    _uow.Fracciones.Borrar(fraccSidixSinContraparte);
                }

                foreach( var fraccAutocadSinContraparte in resumen.FraccionesAutocadQueNoTienenContraparte)
                {
                    Fraccion nuevaFraccion = factory.CrearFraccionAPartirDeTerrenoAutocad(fraccAutocadSinContraparte);
                    _uow.Fracciones.Agregar(nuevaFraccion);
                }


                // VIALIDADES
                foreach (var pareja in resumen.ObtenerVialidadesQueNomasModificaronNombre())
                {
                    string nuevoNombre = pareja.VialidadAutocad.ViaNombre;
                    pareja.VialidadSidix.Nombre = nuevoNombre;
                    _uow.Vialidades.Update(pareja.VialidadSidix);
                }

                foreach (var pareja in resumen.ObtenerVialidadesQueNomasModificaronTramo())
                {
                    string nuevoTramo = pareja.VialidadAutocad.ViaTramo;
                    pareja.VialidadSidix.Tramo = nuevoTramo;
                    _uow.Vialidades.Update(pareja.VialidadSidix);
                }

                foreach (var pareja in resumen.ObtenerVialidadesQueModificaronNombreYTramo())
                {
                    string nuevoNombre = pareja.VialidadAutocad.ViaNombre;
                    string nuevoTramo = pareja.VialidadAutocad.ViaTramo;
                    pareja.VialidadSidix.Nombre = nuevoNombre;
                    pareja.VialidadSidix.Tramo = nuevoTramo;
                    _uow.Vialidades.Update(pareja.VialidadSidix);
                }

                foreach (var vialidadSidixSinContraparte in resumen.VialidadesSidixQueNoTienenContraparte)
                {
                    _uow.Vialidades.Borrar(vialidadSidixSinContraparte);
                }

                foreach (var vialidadAutocadSinContraparte in resumen.VialidadesAutocadQueNoTienenContraparte)
                {
                    VialPoly va = vialidadAutocadSinContraparte;
                    Vialidad nuevaVialidad = new Vialidad()
                    {
                        Nombre = va.ViaNombre,
                        Tramo = va.ViaTramo,
                        Geometria = va.Geom
                    };
                    _uow.Vialidades.Agregar(nuevaVialidad);
                }
                
                // GUARDAR CAMBIOS
                try
                {
                    _uow.SaveToDB();
                    return RedirectToAction("Index", "Home");
                }
                catch (DbEntityValidationException ex)
                {
                    var sb = new StringBuilder();

                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }

                    throw new DbEntityValidationException(
                        "Entity Validation Failed - errors follow:\n" +
                        sb.ToString(), ex
                    ); // Add the original exception as the innerException
                }

            //}
            //else
            //{
            //    return RedirectToAction("ConfirmarCambios");
            //}
        }

        private async Task<IDetectorDeCambiosAutocad> ObtenerDetectorDeCambios()
        {
            IEnumerable<Fraccion> FraccionesSidix = new Fraccion[] { };
            IEnumerable<FeatureFraccion> FraccionesAutocad = new FeatureFraccion[] { };
            IEnumerable<VialPoly> VialidadesAutocad = new VialPoly[] { };
            IEnumerable<Vialidad> VialidadeSidix = new Vialidad[] { };

            var obtenerInfoDePlanosSidix = Task.Run(() =>
            {
                FraccionesSidix = _uow.Fracciones.Obtener("SubdivisionLegal");
                VialidadeSidix = _uow.Vialidades.Obtener();
            });

            var obtenerInfoDePlanosAutocad = Task.Run(() =>
            {
                FraccionesAutocad = _uow.Gis.ObtenerFracciones();
                VialidadesAutocad = _uow.Gis.ObtenerPoligonosVialidades();
            });

            await Task.WhenAll(obtenerInfoDePlanosSidix, obtenerInfoDePlanosAutocad);

            return new DetectorDeCambiosAutocad(
                fraccionesActuales: FraccionesSidix,
                fraccionesNuevas: FraccionesAutocad,
                vialidadesActuales: VialidadeSidix,
                vialidadesNuevas: VialidadesAutocad);
        }

       
    }
}