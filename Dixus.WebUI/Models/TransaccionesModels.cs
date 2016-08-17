using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dixus.Entidades;

namespace Dixus.WebUI.Models
{
    public class TransaccionesIndexViewModel
    {
        IEnumerable<Inversion> Inversiones { get; set; }
        IEnumerable<Ingreso> Ingresos { get; set; }
    }
}