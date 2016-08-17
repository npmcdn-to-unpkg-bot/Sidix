using Dixus.Entidades;
using Dixus.Entidades.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.CambiosAutocad.Entidades
{
    public class ResumenDeCambiosFraccionesAutocad
    {
        public IEnumerable<Fraccion> FraccionesSidixQueNoTienenContraparte { get; set; }
        public IEnumerable<FeatureFraccion> FraccionesAutocadQueNoTienenContraparte { get; set; }
        public IEnumerable<ModificacionAPropiedadesDeFraccion> FraccionesSinModificacionAforma { get; set; }
    
    }
}
