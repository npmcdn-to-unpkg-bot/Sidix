using Dixus.Entidades;
using Dixus.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dixus.WebUI.Models
{
    public class SingleUserViewModel
    {
        public MyUser Usuario { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }

    public class JuntaViewModel
    {
        public JuntaDeConsejo Junta { get; set; }
    }

    public class TareaViewModel
    {
        public Tarea Tarea { get; set; }
    }

    public class NuevaTareaViewModel
    {

    }

    public class NuevoAcuerdoViewModel
    {
        public int JuntaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
    }

    public class NuevaJuntaViewModel
    {
        public string Titulo { get; set; }
        //public string EsDelDiaEnQueSeCreo{ get; set; }
        public DateTime FechaEnQueSucedio { get; set; }
        public string Observaciones { get; set; }
    }
}