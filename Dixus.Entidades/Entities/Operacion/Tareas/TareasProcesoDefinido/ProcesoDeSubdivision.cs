using Dixus.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    //[Table("ProcesosDeSubdivision"/*, Schema = "Operacion"*/)]
    public class ProcesoDeSubdivision : TareaConProcesoDefinido, IValidatableObject
    {
        public override double ObtenerPorcentajeDeProgreso()
        {
            if ( !SolicitudParaDesarrolloUrbanoCompletada ) return 0;
            if ( !RecibioProyectosDeEscrituraDeNotaria ) return .25;
            if ( !FirmaDeProyectoFinalCompletada ) return .5;
            if ( !EscrituraFinalRegistradaAnteRegistroPublico ) return .75;
            else return 1;
        }
        public override string DescripcionDelUltimoPasoCompletado()
        {
            if (!SolicitudParaDesarrolloUrbanoCompletada) return "";
            if (!RecibioProyectosDeEscrituraDeNotaria) return "Se envió solicitud de subdivisión a desarrollo urbano";
            if (!FirmaDeProyectoFinalCompletada) return "Se recibieron proyectos de escritura de la notaría";
            if (!EscrituraFinalRegistradaAnteRegistroPublico) return "Se firmó proyecto final de escritura";
            else return "Se registró escritura final ante Registro Publico de Propiedad";
        }
        public override string DescripcionDePasoSiguiente()
        {
            if (!SolicitudParaDesarrolloUrbanoCompletada) return "Mandar solicitud de subdivisión a Desarrollo Urbano";
            if (!RecibioProyectosDeEscrituraDeNotaria) return "Recibir proyecto de subdivisión de la notaría y validarlo por el área técnica, administrativa y legal";
            if (!FirmaDeProyectoFinalCompletada) return "Firmar proyecto final enviado por la notaría";
            if (!EscrituraFinalRegistradaAnteRegistroPublico) return "Registrar escritura final ante Registro Público de Propiedad";
            else return "";
        }
        public override bool ChecarSiEstaCompletada()
        {
            return EscrituraFinalRegistradaAnteRegistroPublico ? true : false;
        }

        public bool SolicitudParaDesarrolloUrbanoCompletada { get; set; }
        public bool RecibioProyectosDeEscrituraDeNotaria { get; set; }
        public bool FirmaDeProyectoFinalCompletada { get; set; }
        public bool EscrituraFinalRegistradaAnteRegistroPublico { get; set; }

        public virtual ICollection<FraccionLegal> Subdivisiones { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RecibioProyectosDeEscrituraDeNotaria && !SolicitudParaDesarrolloUrbanoCompletada)
                yield return new ValidationResult("");

            if (FirmaDeProyectoFinalCompletada && !RecibioProyectosDeEscrituraDeNotaria)
                yield return new ValidationResult("");

            if (EscrituraFinalRegistradaAnteRegistroPublico && !FirmaDeProyectoFinalCompletada)
                yield return new ValidationResult("");

            yield return null;
        }
    }

   

}
