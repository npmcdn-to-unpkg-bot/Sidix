using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dixus.Entidades
{
    //[Table("Clientes"/* , Schema = "Financiero"*/)]
    public class Cliente : Entidad
    {
        public int ClienteId { get; set; }
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<FraccionLegal> Subdivisiones { get; set; }
        public virtual ICollection<ProcesoDeCompraventa> ProcesosDeCompraventa { get; set; }

        // METODOS
        public IEnumerable<Fraccion> FraccionesQueHaComprado()
        {
            return SubdivisionesQueHaComprado().SelectMany(x=>x.FraccionesPlanMaestro);
        }
        public IEnumerable<Fraccion> FraccionesQueSeLeHanDonado()
        {
            return SubdivisionesQueSeLeHanDonado().SelectMany(x => x.FraccionesPlanMaestro);
        }
        public IEnumerable<Fraccion> FraccionesComprometidas()
        {
            return SubdivisionesComprometidas().SelectMany(x => x.FraccionesPlanMaestro);
        }
        public IEnumerable<Fraccion> FraccionesEnGarantia()
        {
            return SubdivisionesEnGarantia().SelectMany(x => x.FraccionesPlanMaestro);
        }
        public IEnumerable<Fraccion> FraccionesEnProcesoDeCompra()
        {
            return SubdivisionesEnProcesoDeCompra().SelectMany(x => x.FraccionesPlanMaestro);
        }

        public IEnumerable<FraccionLegal> SubdivisionesActivas()
        {
            return Subdivisiones.Where(sub => sub.Descontinuada == false);
        }
        public IEnumerable<FraccionLegal> SubdivisionesQueHaComprado()
        {
            return SubdivisionesActivas().Where(sub => sub.Estatus == EstatusDeSubdivision.Vendida);
        }
        public IEnumerable<FraccionLegal> SubdivisionesQueSeLeHanDonado()
        {
            return SubdivisionesActivas().Where(sub => sub.Estatus == EstatusDeSubdivision.Donada);
        }
        public IEnumerable<FraccionLegal> SubdivisionesComprometidas()
        {
            return SubdivisionesActivas().Where(sub => sub.Estatus == EstatusDeSubdivision.Comprometida);
        }
        public IEnumerable<FraccionLegal> SubdivisionesEnGarantia()
        {
            return SubdivisionesActivas().Where(sub => sub.Estatus == EstatusDeSubdivision.Garantia);
        }
        public IEnumerable<FraccionLegal> SubdivisionesEnProcesoDeCompra()
        {
            return ProcesosDeCompraventa.SelectMany(proc => proc.Subdivisiones);
        }

        public int NumeroDeFraccionesQueHaComprado()
        {
            return FraccionesQueHaComprado().Count();
        }
        public int NumeroDeFraccionesQueSeLeHanDonado()
        {
            return FraccionesQueSeLeHanDonado().Count();
        }
        public int NumeroDeFraccionesComprometidas()
        {
            return FraccionesComprometidas().Count();
        }
        public int NumeroDeFraccionesEnGarantia()
        {
            return FraccionesEnGarantia().Count();
        }
        public int NumeroDeFraccionesEnProcesoDeCompra()
        {
            return FraccionesEnProcesoDeCompra().Count();
        }

        public int NumeroDeSubdivisionesQueHaComprado()
        {
            return SubdivisionesQueHaComprado().Count();
        }
        public int NumeroDeSubdivisionesQueSeLeHanDonado()
        {
            return SubdivisionesQueSeLeHanDonado().Count();
        }
        public int NumeroDeSubdivisionesComprometidas()
        {
            return SubdivisionesComprometidas().Count();
        }
        public int NumeroDeSubdivisionesEnGarantia()
        {
            return SubdivisionesEnGarantia().Count();
        }
        public int NumeroDeSubdivisionesEnProcesoDeCompra()
        {
            return SubdivisionesEnProcesoDeCompra().Count();
        }
    }
}