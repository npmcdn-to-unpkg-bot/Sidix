using Dixus.Repositorios.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dixus.Entidades;
using Dixus.Domain;
using Dixus.Entidades.Gis;
using System.Data.Entity;

namespace Dixus.Repositorios.Concrete
{
    public class GisRepository : IGisRepository
    {
        private AutocadContext Context;
        public GisRepository()
        {
            Context = new AutocadContext();
        }

        public async Task<double> ObtenerAreaTotalDeFracciones()
        {
            var area = await Context.Fracciones.SumAsync(x => x.Geometry.Area);
            return area ?? 0;
        }
        public async Task<double> ObtenerAreaTotalDePlanos()
        {
            var areaFracciones = await ObtenerAreaTotalDeFracciones();
            var areaVialidades = await ObtenerAreaTotalDeVialidades();
            return areaFracciones + areaVialidades;
        }
        public async Task<double> ObtenerAreaTotalDeVialidades()
        {
            var area = await Context.VialidadesPoligonos.SumAsync(x => x.Geom.Area);
            return area ?? 0;
        }

        public async Task<IEnumerable<VialEje>> ObtenerEjesVialidadesAsync()
        {
            return await Context.VialidadesEjes.ToListAsync();
        }
        public async Task<IEnumerable<FeatureFraccion>> ObtenerFraccionesAsync()
        {
            return await Context.Fracciones.ToListAsync();   
        }
        public async Task<IEnumerable<VialPoly>> ObtenerPoligonosVialidadesAsync()
        {
            return await Context.VialidadesPoligonos.ToListAsync();
        }

        public IEnumerable<VialEje> ObtenerEjesVialidades()
        {
            return Context.VialidadesEjes.ToList();
        }
        public IEnumerable<FeatureFraccion> ObtenerFracciones()
        {
            return Context.Fracciones.ToList();
        }
        public IEnumerable<VialPoly> ObtenerPoligonosVialidades()
        {
            return Context.VialidadesPoligonos.ToList();
        }
    }
}
