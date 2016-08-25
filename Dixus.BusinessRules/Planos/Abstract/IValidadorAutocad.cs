using Dixus.BusinessRules.Planos.Entidades;
using Dixus.BusinessRules.Planos.Entidades.Validacion;
using Dixus.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.Planos.Abstract
{
    public interface IValidadorAutocad
    {
        Task<bool> ChecarSiModeloAutocadEsValido(OpcionesDeValidacionAutocad opciones);

        // AREA
        Task<bool> AutocadTieneSuperficieValida(double areaQueDeberiaTenerElProyecto, double margenDeErrorEnMetrosCuadrados);

        // GEOMTRIAS SON POLIGONOS
        Task<bool> TodasLasGoometriasSonPoligonos();
        Task<PoligonosAutocadQueNoPasaronValidacion> ObtenerGeometriasQueNoSonPoligonos();

        // POLIGONOS ESTAN CERRADOS
        Task<bool> TodosLosPoligonosEstanCerrados();
        Task<PoligonosAutocadQueNoPasaronValidacion> ObtenerPoligonosNoCerrados();

        // POLIGONOS SON VALIDOS
        Task<bool> TodosLosPoligonosSonValidos();
        Task<PoligonosAutocadQueNoPasaronValidacion> ObtenerPoligonosInvalidos();

        // POLIGONOS NO SE SOBREPONEN
        Task<bool> NiUnPoligonoSeSobrepone(double tamañoMaximoDeSobreposiciones);
        Task<IEnumerable<GeometriaSobrepuesta>> ObtenerAreasSobrepuestas(double tamañoMaximoPermitidoDeSobreposiciones);

        Task<bool> TodasLasFraccionesQueCambiaranSonModificables(IEnumerable<Fraccion> fraccionesQueCambiaran);
        Task<IEnumerable<Fraccion>> ObtenerFraccionesQueCambiaranQueSonInmodificables(IEnumerable<Fraccion> fraccionesQueCambiaran);


    }
}
