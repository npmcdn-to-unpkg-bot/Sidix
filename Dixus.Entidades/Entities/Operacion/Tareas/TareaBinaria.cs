using Dixus.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    public class TareaBinaria : Tarea
    {
        public bool Completada { get; set; }

        public override double ObtenerPorcentajeDeProgreso()
        {
            return Completada ? 1 : 0;
        }
        public override bool ChecarSiEstaCompletada()
        {
            return Completada;
        }

    }
    

   

}
