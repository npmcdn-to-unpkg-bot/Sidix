using Dixus.BusinessRules.CambiosAutocad.Entidades;
using Dixus.Entidades;
using Dixus.Entidades.Gis;
using Dixus.Repositorios.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.CambiosAutocad.Abstract
{
    public interface IDetectorDeCambiosAutocad
    {
        IEnumerable<Fraccion> ObtenerSetDeFraccionesActuales();
        IEnumerable<FeatureFraccion> ObtenerSetDeFraccionesNuevas();
        IEnumerable<Vialidad> ObtenerSetDeVialidadesActuales();
        IEnumerable<VialPoly> ObtenerSetDeVialidadesNuevas();

        bool ChecarSiModeloHaCambiado();
        Task<ResumenDeCambiosAutocad> ObtenerResumenDeCambios();
    }
    

}
