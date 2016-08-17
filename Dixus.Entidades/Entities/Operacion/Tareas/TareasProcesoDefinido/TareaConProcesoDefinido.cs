using Dixus.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
       public abstract class TareaConProcesoDefinido : Tarea
    {
        public abstract string DescripcionDelUltimoPasoCompletado();
        public abstract string DescripcionDePasoSiguiente();
    }
    

   

}
