using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dixus.Entidades
{
    [Table("TiposDeSuelo")]
    public class TipoDeSuelo : Entidad
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Color { get; set; }
        public int TipoDeSueloId { get; set; }
        public double MvaPorHectarea { get; set; }
        public double? TuDeReferencia { get; set; }

        /// <summary>
        /// IMPORTANTE: Este propiedad puede incluir fracciones que están descontinuadas. Para una lista de fracciones activas, utilizar el método "ObtenerFraccionesActivas()"
        /// </summary>
        public virtual ICollection<Fraccion> Fracciones { get; set; }
        public IEnumerable<Fraccion> ObtenerFraccionesActivas()
        {
            return Fracciones.Where(fracc => fracc.Descontinuada == false);
        }
    }

    public enum TiposDeSuelo
    {
        //to do: ponerlos por categorias, ex: 1-10, 11-20, etc.
        ViviendaEconomica = 1,
        ViviendaSocial = 2,
        ViviendaPopular = 3,
        ViviendaMedia = 4,
        ViviendaResidencial = 5,
        Comercial = 6,
        ComercioYServicios = 7,
        Industrial = 8,
        ParqueAltaTecnologia = 9,
        ServiciosEspeciales = 10,
        AreaConservacion = 11,
        ReservaEstrategica = 12,
        EquipamentoUrbano = 13,
        Donaciones = 14
    }
}