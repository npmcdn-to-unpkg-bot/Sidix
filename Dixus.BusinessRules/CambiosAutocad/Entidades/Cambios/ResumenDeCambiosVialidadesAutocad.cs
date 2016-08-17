using Dixus.Entidades;
using Dixus.Entidades.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.CambiosAutocad.Entidades
{
    public class ResumenDeCambiosVialidadesAutocad
    {
        public IEnumerable<Vialidad> VialidadesSidixQueNoTienenContraparte { get; set; }
        public IEnumerable<VialPoly> VialidadesAutocadQueNoTienenContraparte { get; set; }
        public IEnumerable<ModificacionAPropiedadesDeVialidad> VialidadesSinModificacionAforma { get; set; }
    }
}
