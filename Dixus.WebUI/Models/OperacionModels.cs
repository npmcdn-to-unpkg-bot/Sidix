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

    }

    public class NuevaJuntaViewModel
    {

    }
}