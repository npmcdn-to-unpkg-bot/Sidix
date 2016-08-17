using Dixus.BusinessRules.ProyectosDeInversion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.ProyectosDeInversion
{
    public interface ICalculadoraPorcentajesDeTu
    {
        PorcentajesDeTu ObtenerPorcentajes();
        double ObtenerPorcentajeDeTierra();
        double ObtenerPorcentajeDeGastosPorFraccionar();
        double ObtenerPorcentajeDeInfraestructura();
        double ObtenerPorcentajeDeObrasEspeciales();
        double ObtenerPorcentajeDeUrbanizacion();
        double ObtenerPorcentajeDePostVenta();
    }
}
