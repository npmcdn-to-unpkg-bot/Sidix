using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dixus.WebUI.Models
{
    public class RegistrarCompraVentaViewModel
    {
        public int FraccionId { get; set; }
        public string NombreDeFraccion { get; set; }

        public int ClienteId { get; set; }
        public int FraccionLegalId { get; set; }
        
        public DateTime FechaDeCompraVenta { get; set; }
        public byte[] Pdf { get; set; }
    }
}