using Dixus.Entidades.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.Planos.Entidades
{
    public class PoligonosAutocadQueNoPasaronValidacion
    {
        public PoligonosAutocadQueNoPasaronValidacion()
        {
            Fracciones = new List<FeatureFraccion>();
            Vialidades = new List<VialPoly>();
        }

        public List<FeatureFraccion> Fracciones { get; set; }
        public List<VialPoly> Vialidades { get; set; }

        public bool EstaVacio { get { return Fracciones.Count == 0 && Vialidades.Count == 0; } }
    }
}
