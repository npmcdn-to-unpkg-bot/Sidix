using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dixus.Entidades.Identity
{
    public class MyUser : IdentityUser
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Puesto { get; set; }
        public string NombreCompleto { get { return Nombre + " " + Apellido; } }

        public virtual ICollection<JuntaDeConsejo> JuntasAsistidas { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }

        // methods
        public int NumDeTareasCompletadas()
        {
            return TareasCompletadas().Count();
        }
        public int NumDeTareasPorCompletar()
        {
            return TareasPorCompletar().Count();
        }
        public int NumDeJuntasAsistidas()
        {
            return JuntasAsistidas.Count();
        }
        public IEnumerable<JuntaDeConsejo> UltimasJuntasAsistidas(int howmany)
        {
            return JuntasAsistidas.OrderByDescending(junta => junta.Fecha).Take(howmany);
        }
        public IEnumerable<Tarea> TareasCompletadas()
        {
            return Tareas.Where(tarea => tarea.ChecarSiEstaCompletada() == true);
        }
        public IEnumerable<Tarea> TareasPorCompletar()
        {
            return Tareas.Where(tarea => tarea.ChecarSiEstaCompletada() == false);
        }
        public IEnumerable<Tarea> TareasCompletadas(int howmany)
        {
            return TareasCompletadas().OrderByDescending(tarea => tarea.JuntaDeConsejo.Fecha).Take(howmany);
        }
        public IEnumerable<Tarea> TareasPorCompletar(int howmany)
        {
            return TareasPorCompletar().OrderByDescending(tarea => tarea.JuntaDeConsejo.Fecha).Take(howmany);
        }



    }

}
