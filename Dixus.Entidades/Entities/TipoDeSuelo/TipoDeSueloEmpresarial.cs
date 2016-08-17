using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.Entidades
{
    public class TipoDeSueloEmpresarial : TipoDeSuelo
    {
        public double PorcentajeParaDemanda { get; set; }
        public double LpsPorHectareaParaDemanda { get; set; }
    }
}
