using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using Dixus.Entidades;
using Dixus.BusinessRules.ProyectosDeInversion.Entidades;
using Dixus.BusinessRules;

namespace Dixus.WebUI.Models
{
  
    public class ProyectosInversionViewModel
    {
        public Fraccion Fraccion { get; set; }
        public TuMacronanzanaYDesarrollador AnalisisTU { get; set; }
        public AnalisisDePrecioDeVenta AnalisisDePrecioDeVenta { get; set; }
                    
    }
}
