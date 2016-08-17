using Dixus.Entidades;
using Dixus.Entidades.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Abstract
{
    public interface IGisRepository
    {
        IEnumerable<FeatureFraccion> ObtenerFracciones();
        IEnumerable<VialPoly> ObtenerPoligonosVialidades();
        IEnumerable<VialEje> ObtenerEjesVialidades();

        Task<IEnumerable<FeatureFraccion>> ObtenerFraccionesAsync();
        Task<IEnumerable<VialPoly>> ObtenerPoligonosVialidadesAsync();
        Task<IEnumerable<VialEje>> ObtenerEjesVialidadesAsync();

        Task<double> ObtenerAreaTotalDePlanos();
        Task<double> ObtenerAreaTotalDeFracciones();
        Task<double> ObtenerAreaTotalDeVialidades();
    }
}
