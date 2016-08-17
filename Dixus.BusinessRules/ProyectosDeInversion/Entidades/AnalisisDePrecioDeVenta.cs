using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.ProyectosDeInversion.Entidades
{
    public class AnalisisDePrecioDeVenta
    {
        public decimal TuDeReferencia { get; set; }
        public decimal TuDelDesarrollador { get; set; }
        public decimal PrecioDeVentaPorM2Vendible { get; set; }
        public double SuperficieVendible { get; set; }
        public decimal MontoDeLaOperacion { get; set; }
        public double SuperficieTotal { get; set; }
        public decimal PrecioDeVentaM2PorValorResidual { get; set; }
        public decimal Ingresos { get; set; }
        public decimal Costos { get; set; }
        public decimal UtilidadBruta { get; set; }
        public double MargenBruto { get; set; }
        public decimal GAV { get; set; }
        public decimal CIF { get; set; }
        public decimal UtilidadAntesDeImpuestos { get; set; }
        public decimal Impuestos { get; set; }
        public decimal UtilidadNeta { get; set; }
        public double MargenNeto { get; set; }

    }
}
