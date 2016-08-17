using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.Entidades
{
    public class TipoDeSueloVivienda : TipoDeSuelo
    {
        public double ViviendaPorHectareaPromedio { get; set; }
        public double HabitantesPorViviendaPromedio { get; set; }
    }
}
