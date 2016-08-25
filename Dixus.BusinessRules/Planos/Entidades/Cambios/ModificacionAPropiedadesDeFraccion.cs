using Dixus.Entidades;
using Dixus.Entidades.Gis;

namespace Dixus.BusinessRules.Planos.Entidades
{
    public class ModificacionAPropiedadesDeFraccion
    {
        public ModificacionAPropiedadesDeFraccion(Fraccion sidix, FeatureFraccion autocad)
        {
            FraccionSidix = sidix;
            FraccionAutocad = autocad;
        }

        public Fraccion FraccionSidix { get; private set; }
        public FeatureFraccion FraccionAutocad { get; private set; }

        public bool CambioDeNombre { get { return FraccionSidix.Nombre != FraccionAutocad.Nombre; } }
        public bool CambioDeUsoDeSuelo { get { return FraccionSidix.TipoDeSueloId != FraccionAutocad.ObtenerUsoDeSueloId(); } }

    }

}
