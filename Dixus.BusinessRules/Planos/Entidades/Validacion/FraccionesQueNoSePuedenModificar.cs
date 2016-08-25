using Dixus.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.Planos.Entidades.Validacion
{
    public class FraccionesQueNoSePuedenModificar
    {
        public bool EstaVacio
        {
            get
            {
                return FraccionesQueEstanVendidas.Count() == 0 &&
                    FraccionesQueEstanEnGarantia.Count() == 0 &&
                    FraccionesQueEstanDonadas.Count() == 0 &&
                    FraccionesQueEstanComprometidas.Count() == 0;
            }
        }
        public IEnumerable<Fraccion> FraccionesQueEstanVendidas { get; set; }
        public IEnumerable<Fraccion> FraccionesQueEstanEnGarantia { get; set; }
        public IEnumerable<Fraccion> FraccionesQueEstanDonadas { get; set; }
        public IEnumerable<Fraccion> FraccionesQueEstanComprometidas { get; set; }
    }
}
