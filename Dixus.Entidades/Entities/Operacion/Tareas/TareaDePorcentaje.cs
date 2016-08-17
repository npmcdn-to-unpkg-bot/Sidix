using Dixus.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    public class TareaDePorcentaje : Tarea
    {
        [Range(minimum: 0, maximum: 1, ErrorMessage = "El porcentaje de avance debe de ser un decimal entre 0 y 1 (0-100%)")]
        public double PorcentajeDeAvance { get; set; }

        public override double ObtenerPorcentajeDeProgreso()
        {
            return PorcentajeDeAvance;
        }
        public override bool ChecarSiEstaCompletada()
        {
            return PorcentajeDeAvance == 1 ? true : false;
        }

        
    }
    

   

}
