using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.Entidades
{
    [Table("FraccionesLegales"/*, Schema = "Legal"*/)]
    public class FraccionLegal : Entidad, IValidatableObject
    {
        public int FraccionLegalId { get; set; }
        public string Nombre { get; set; }
        public string ClaveCatastral { get; set; }
        public double Superficie { get; set; }
        public EstatusDeSubdivision Estatus { get; set; }

        public DateTime? FechaDeOtorgamiento { get; set; }
        public int VolumenSubdivision { get; set; }

        public int NumeroDeRPP { get; set; }
        public int VolumenRPP { get; set; }
        public DateTime? FechaDeInscripcion { get; set; }

        public string Observaciones { get; set; }
        public bool Descontinuada { get; set; }
        public DateTime? FechaDescontinuada { get; set; }

        [ForeignKey("EscrituraDeSubdivision")]
        public int EscrituraSubdivisionId { get; set; }
        public virtual EscrituraDeSubdivision EscrituraDeSubdivision { get; set; }

        [ForeignKey("EscrituraDeTraspaso")]
        public int? EscrituraDeTraspasoId { get; set; }
        public virtual EscrituraDeTraspaso EscrituraDeTraspaso { get; set; }

        // Procesos actuales
        [ForeignKey("ProcesoDeSubdivision")]
        public int? ProcesoDeSubdivisionId { get; set; }
        /// <summary>
        /// Si tiene un valor, representa el proceso en el cual esta subdivisión legal, opcionalmente en conjunto con otras, está siendo dividida en otras partes. Si está en proceso de subdivisión (es NOT NULL), la fracción no puede empezar otro proceso como compraventa, ponerse en garantía, etc.
        /// </summary>
        public virtual ProcesoDeSubdivision ProcesoDeSubdivision { get; set; }

        [ForeignKey("ProcesoDeCompraventa")]
        public int? ProcesoDeCompraventaId { get; set; }
        /// <summary>
        /// Si tiene un valor, representa el proceso en el cual esta subdivisión legal, opcionalmente en conjunto con otras, está siendo vendida/comprada a un cliente en especifico. Si está en proceso de compraventa (es NOT NULL), la fracción no puede empezar otro proceso como subdividirse, ponerse en garantía, etc.
        /// </summary>
        public virtual ProcesoDeCompraventa ProcesoDeCompraventa { get; set; }

        // Navigation properties
        /// <summary>
        /// Define a las personas/empresas que compraron, se les dono, tienen en garantia comprometida, etc. la fraccion. Si la fraccion esta libre, Clientes debe de estar vacio y viceversa.
        /// </summary>
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Fraccion> FraccionesPlanMaestro { get; set; }

        // Metodos
        public string ObtenerNombresDeClientes()
        {
            if (Clientes == null)
            {
                return String.Empty;
            }
            else
            {
                return String.Join(", ",Clientes.Select(cli => cli.Nombre));
            }
        }

        // Validacion
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int numDeClientes = Clientes == null ? 0 : Clientes.Count();
            if (Estatus == EstatusDeSubdivision.Libre)
            {
                if (numDeClientes != 0) yield return new ValidationResult("Subdivisiones libres no pueden tener ni un cliente registrado", new string[] { "Estatus" });
            }
            else
            {
                if (numDeClientes == 0) yield return new ValidationResult("Las fracciones que no estén libres (ya sea vendidas, en garantía, donadas, etc.) deben de tener al menos un cliente registrado");

                if (EscrituraDeTraspasoId == null) yield return new ValidationResult("Las fracciones que no estén libres (ya sea vendidas, en garantía, donadas, etc.) deben de tener una escritura o documento de traspaso asignado");

            }
        }
    }

}
