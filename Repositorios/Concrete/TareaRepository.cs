using System;
using System.Collections.Generic;
using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using System.Linq;

namespace Dixus.Repositorios.Concrete
{
    public class TareaRepository : Repository<Tarea>, ITareaRepository
    {
        public DixusContext DixusContext { get { return Context as DixusContext; } }
        public TareaRepository(DixusContext context) : base(context)
        {

        }
        
        public IEnumerable<TTarea> ObtenerTipoEspecificoDeTarea<TTarea>() where TTarea : Tarea
        {
            return DixusContext.Tareas.OfType<TTarea>().ToList();
        }
        public IEnumerable<TTarea> ObtenerTareasCompletadas<TTarea>() where TTarea : Tarea
        {
            return DixusContext.Tareas.OfType<TTarea>().Where(
               tarea =>
                  tarea.ChecarSiEstaCompletada() == true &&
                  tarea.ObtenerPorcentajeDeProgreso() == 1).ToList();
        }
        public IEnumerable<TTarea> ObtenerTareasSinCompletar<TTarea>() where TTarea : Tarea
        {
            return DixusContext.Tareas.OfType<TTarea>().Where(
                tarea =>
                    tarea.ChecarSiEstaCompletada() == false &&
                    tarea.ObtenerPorcentajeDeProgreso() < 1).ToList();
        }
        public IEnumerable<TTarea> ObtenerTareasEnProceso<TTarea>() where TTarea : Tarea
        {
            return DixusContext.Tareas.OfType<TTarea>().Where(
                tarea =>
                    tarea.ChecarSiEstaCompletada() == false &&
                    tarea.ObtenerPorcentajeDeProgreso() > 0 &&
                    tarea.ObtenerPorcentajeDeProgreso() < 1).ToList();
        }
        public IEnumerable<TTarea> ObtenerTareasSinEmpezar<TTarea>() where TTarea : Tarea
        {
            return DixusContext.Tareas.OfType<TTarea>().Where(
                tarea =>
                    tarea.ChecarSiEstaCompletada() == false &&
                    tarea.ObtenerPorcentajeDeProgreso() == 0).ToList();
        }
        public IEnumerable<TTarea> ObtenerTareasArribaDeCiertoPorcentaje<TTarea>(double porcentaje) where TTarea : Tarea
        {
            return DixusContext.Tareas.OfType<TTarea>().Where(
                tarea =>
                    tarea.ObtenerPorcentajeDeProgreso() > porcentaje).ToList();
        }
        public IEnumerable<TTarea> ObtenerTareasDebajoDeCiertoPorcentaje<TTarea>(double porcentaje) where TTarea : Tarea
        {
            return DixusContext.Tareas.OfType<TTarea>().Where(
                tarea =>
                    tarea.ObtenerPorcentajeDeProgreso() < porcentaje).ToList();
        }
        public IEnumerable<TTarea> ObtenerTareasMasRecientes<TTarea>(int howmany) where TTarea : Tarea
        {
            return DixusContext.Tareas.OfType<TTarea>().OrderByDescending(tar => tar.JuntaDeConsejo.Fecha).Take(howmany).ToList();
        }
    }
}
