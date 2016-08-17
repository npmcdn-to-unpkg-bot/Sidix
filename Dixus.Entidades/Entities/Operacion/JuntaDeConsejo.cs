using Dixus.Entidades.Identity;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    [Table("JuntasDeConsejo")]
    public class JuntaDeConsejo : Entidad
    {
        [Key]
        public int JuntaDeConsejoId { get; set; }
        [Required]
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string Objetivo { get; set; }
        public string Observaciones { get; set; }

        public virtual ICollection<AcuerdoDeConsejo> Acuerdos { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
        public virtual ICollection<MyUser> UsuariosPresentes { get; set; }

        // Metodos
        public int NumDeAcuerdosAlcanzados()
        {
            return Acuerdos.Count;
        }
        public int NumDeTareasAsignadas()
        {
            return Tareas.Count;
        }
        public int NumDeTareasCompletadas()
        {
            return TareasCompletadas().Count();
        }
        public int NumDeTareasPendientes()
        {
            return TareasPendientes().Count();
        }
        public int NumDeUsuariosPresentes()
        {
            return UsuariosPresentes.Count;
        }
        public IEnumerable<Tarea> TareasCompletadas()
        {
            return Tareas.Where(tarea => tarea.ChecarSiEstaCompletada() == true);
        }
        public IEnumerable<Tarea> TareasPendientes()
        {
            return Tareas.Where(tarea => tarea.ChecarSiEstaCompletada() == false);
        }
        public IEnumerable<Tarea> TareasCompletadas(int howmany)
        {
            return TareasCompletadas().OrderByDescending(x => x.JuntaDeConsejo.Fecha).Take(howmany);
        }
        public IEnumerable<Tarea> TareasPendientes(int howmany)
        {
            return TareasPendientes().OrderByDescending(x => x.JuntaDeConsejo.Fecha).Take(howmany);
        }
    }
      

}
