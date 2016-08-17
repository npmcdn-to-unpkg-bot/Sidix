using Dixus.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    //[Table("ProcesosDeCompraventa"/*, Schema = "Operacion"*/)]
    public class ProcesoDeCompraventa : TareaConProcesoDefinido, IValidatableObject
    {
        public override bool ChecarSiEstaCompletada()
        {
            return SeRegistroEscrituraFinalAnteRegistroPublico ? true : false;
        }
        public override double ObtenerPorcentajeDeProgreso()
        {
            if (!SeEnvioDatosANotaria) return 0;
            if (!SeRecibioProyectosDeCompraventaDeNotaria) return .25;
            if (!SeFirmoEscrituraFinal) return .5;
            if (!SeRegistroEscrituraFinalAnteRegistroPublico) return .75;
            else return 1;
        }
        public override string DescripcionDelUltimoPasoCompletado()
        {
            if (!SeEnvioDatosANotaria) return "";
            if (!SeRecibioProyectosDeCompraventaDeNotaria) return "Se enviaron datos a la notaría";
            if (!SeFirmoEscrituraFinal) return "Se recibió proyecto de compraventa de la notaría";
            if (!SeRegistroEscrituraFinalAnteRegistroPublico) return "Se firmó la escritura final";
            else return "Se registró la escritura final ante el Registro Público";
        }
        public override string DescripcionDePasoSiguiente()
        {
            if (!SeEnvioDatosANotaria) return "Enviar datos de compraventa a la notaría";
            if (!SeRecibioProyectosDeCompraventaDeNotaria) return "Esperar/subir proyecto de compraventa de la notaría";
            if (!SeFirmoEscrituraFinal) return "Firmar escritura final de compraventa";
            if (!SeRegistroEscrituraFinalAnteRegistroPublico) return "Registrar escritura final firmada ante Registro Público";
            else return "";
        }

        public bool SeEnvioDatosANotaria { get; set; }
        public bool SeRecibioProyectosDeCompraventaDeNotaria { get; set; }
        public bool SeFirmoEscrituraFinal { get; set; }
        public bool SeRegistroEscrituraFinalAnteRegistroPublico { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<FraccionLegal> Subdivisiones { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SeRecibioProyectosDeCompraventaDeNotaria && !SeEnvioDatosANotaria)
                yield return new ValidationResult("");
            if (SeFirmoEscrituraFinal && !SeRecibioProyectosDeCompraventaDeNotaria)
                yield return new ValidationResult("");
            if (SeRegistroEscrituraFinalAnteRegistroPublico && !SeFirmoEscrituraFinal)
                yield return new ValidationResult("");
        }

       
    }

    
   

}
