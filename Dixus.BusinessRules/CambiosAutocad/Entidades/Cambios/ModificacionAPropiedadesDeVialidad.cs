using Dixus.Entidades;
using Dixus.Entidades.Gis;

namespace Dixus.BusinessRules.CambiosAutocad.Entidades
{
    public class ModificacionAPropiedadesDeVialidad
    {
        public ModificacionAPropiedadesDeVialidad(Vialidad sidix, VialPoly autocad)
        {
            VialidadSidix = sidix;
            VialidadAutocad = autocad;
        }

        public Vialidad VialidadSidix { get; private set; }
        public VialPoly VialidadAutocad { get; private set; }

        public bool CambioDeNombre { get { return VialidadSidix.Nombre != VialidadAutocad.ViaNombre; } }
        public bool CambioDeTramo { get { return VialidadSidix.Tramo != VialidadAutocad.ViaTramo; } }
    }
}
