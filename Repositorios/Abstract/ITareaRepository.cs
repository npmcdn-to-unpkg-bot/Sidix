using Dixus.Entidades;
using System;
using System.Collections.Generic;

namespace Dixus.Repositorios.Abstract
{
    public interface ITareaRepository : IRepository<Tarea>
    {

        IEnumerable<TTarea> ObtenerTipoEspecificoDeTarea<TTarea>() where TTarea : Tarea;

        IEnumerable<TTarea> ObtenerTareasMasRecientes<TTarea>(int howmany) where TTarea : Tarea;
        IEnumerable<TTarea> ObtenerTareasCompletadas<TTarea>() where TTarea : Tarea;
        IEnumerable<TTarea> ObtenerTareasSinCompletar<TTarea>() where TTarea : Tarea;
        IEnumerable<TTarea> ObtenerTareasEnProceso<TTarea>() where TTarea : Tarea;
        IEnumerable<TTarea> ObtenerTareasSinEmpezar<TTarea>() where TTarea : Tarea;
        IEnumerable<TTarea> ObtenerTareasArribaDeCiertoPorcentaje<TTarea>(double porcentaje) where TTarea : Tarea;
        IEnumerable<TTarea> ObtenerTareasDebajoDeCiertoPorcentaje<TTarea>(double porcentaje) where TTarea : Tarea;

        IEnumerable<Tarea> ObtenerTareasPorUsuario(string username);
        IEnumerable<TTarea> ObtenerTareasPorUsuario<TTarea>(string username) where TTarea : Tarea;
    }
}
