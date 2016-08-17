using Dixus.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    [Table("Tareas")]
    public abstract class Tarea : Entidad
    {
        [Key]
        public int TareaId { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }

        [ForeignKey("JuntaDeConsejo")]
        public int JuntaDeConsejoId { get; set; }
        public virtual JuntaDeConsejo JuntaDeConsejo { get; set; }

        public virtual ICollection<MyUser> Responsables { get; set; }


        // METODOS
        public abstract double ObtenerPorcentajeDeProgreso();
        public abstract bool ChecarSiEstaCompletada();
        public int NumDeResponsables()
        {
            return Responsables.Count;
        }
    }
    

   

}
