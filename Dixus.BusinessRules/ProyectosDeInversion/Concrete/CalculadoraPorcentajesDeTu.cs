using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dixus.BusinessRules.ProyectosDeInversion.Entidades;
using Dixus.Entidades;

namespace Dixus.BusinessRules.ProyectosDeInversion
{
    public class CalculadoraPorcentajesDeTu : ICalculadoraPorcentajesDeTu
    {
        private Opciones _opciones;
        public CalculadoraPorcentajesDeTu(Opciones opciones)
        {
            _opciones = opciones;
        }

        public double ObtenerPorcentajeDeGastosPorFraccionar()
        {
            return _opciones.PorcentajedeTUPertenecienteAGastosPorFraccionar ?? 0;
        }

        public double ObtenerPorcentajeDeInfraestructura()
        {
            return _opciones.PorcentajedeTUPertenecienteAInfraestructura ?? 0;
        }

        public double ObtenerPorcentajeDeObrasEspeciales()
        {
            return _opciones.PorcentajedeTUPertenecienteAObrasEspeciales ?? 0;
        }

        public double ObtenerPorcentajeDePostVenta()
        {
            return _opciones.PorcentajedeTUPertenecienteAPostVenta ?? 0;
        }

        public double ObtenerPorcentajeDeTierra()
        {
            return _opciones.PorcentajedeTUPertenecienteATierra ?? 0;
        }

        public double ObtenerPorcentajeDeUrbanizacion()
        {
            return _opciones.PorcentajedeTUPertenecienteAUrbanizacion ?? 0;
        }

        public PorcentajesDeTu ObtenerPorcentajes()
        {
            PorcentajesDeTu porcentajes = new PorcentajesDeTu()
            {
                PorcentajeDeGastosPorFraccionar = ObtenerPorcentajeDeGastosPorFraccionar(),
                PorcentajeDeInfraestructura = ObtenerPorcentajeDeInfraestructura(),
                PorcentajeDeObrasEspeciales = ObtenerPorcentajeDeObrasEspeciales(),
                PorcentajeDePostVenta = ObtenerPorcentajeDePostVenta(),
                PorcentajeDeTierra = ObtenerPorcentajeDeTierra(),
                PorcentajeDeUrbanizacion = ObtenerPorcentajeDeUrbanizacion()
            };
            return porcentajes;
        }
    }
}
