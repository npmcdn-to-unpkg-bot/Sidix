using System.Collections.Generic;
using System.Net;

namespace Dixus.WebUI.Models
{
    public class HomeViewModel
    {
        public int NumeroDeFracciones { get; set; }
        public int NumDeClientes { get; set; }
        public int NumDeSubdivisionesLegales { get; set; }

        public List<SueloConArea> SuelosConArea { get; set; }

    }

    public class SueloConArea
    {
        public string name { get; set; }
        public double value { get; set; }
        public string fill { get; set; }
    }

    public class ErrorViewModel
    {
        public HttpStatusCode Estatus { get; set; }
        public ErrorViewModel(HttpStatusCode estatus)
        {
            Estatus = estatus;
        }
    }
    
}