namespace Dixus.Entidades.Gis
{
    using Entidades;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchemaDxs.FeatureFraccion")]
    public partial class FeatureFraccion
    {
        [Key]
        public long FeatId { get; set; }

        [StringLength(20)]
        public string Etapa { get; set; }

        public double? FactorTopo { get; set; }

        [StringLength(20)]
        public string Lote { get; set; }

        [StringLength(20)]
        public string Manzana { get; set; }

        [StringLength(20)]
        public string Nombre { get; set; }

        [StringLength(20)]
        public string Uso { get; set; }

        public DbGeometry Geometry { get; set; }

        [StringLength(20)]
        public string Zona { get; set; }

        // Metodos
        public int ObtenerEtapaEnNumero()
        {
            switch (Etapa)
            {
                case "i":
                    return 1;
                case "ii":
                    return 2;
                case "iii":
                    return 3;
                case "iv":
                    return 4;
                case "v":
                    return 5;
                case "vi":
                    return 6;
                case "vii":
                    return 7;
                case "viii":
                    return 8;
                case "ix":
                    return 9;
                case "x":
                    return 10;
                default:
                    throw new ArgumentOutOfRangeException("Etapa", "La etapa de esta fraccion en número romano no se pudo transformar a número arábigo. Por favor verifica que el número esté en minusculas y se encuentre entre 1 y 10 (i - x)");

            }
        }
        public int ObtenerUsoDeSueloId()
        {
            switch (Uso)
            {
                case "VE": return (int)TiposDeSuelo.ViviendaEconomica;
                case "VS": return (int)TiposDeSuelo.ViviendaSocial;
                case "VP": return (int)TiposDeSuelo.ViviendaPopular;
                case "VM": return (int)TiposDeSuelo.ViviendaMedia;
                case "VR": return (int)TiposDeSuelo.ViviendaResidencial;
                case "COM": return (int)TiposDeSuelo.Comercial;
                case "CS": return (int)TiposDeSuelo.ComercioYServicios;
                case "IND": return (int)TiposDeSuelo.Industrial;
                case "PAT": return (int)TiposDeSuelo.ParqueAltaTecnologia;
                case "SE": return (int)TiposDeSuelo.ServiciosEspeciales;
                case "AC": return (int)TiposDeSuelo.AreaConservacion;
                case "RE": return (int)TiposDeSuelo.ReservaEstrategica;
                case "EQ": return (int)TiposDeSuelo.EquipamentoUrbano;
                case "DON": return (int)TiposDeSuelo.Donaciones;
                default: throw new ArgumentOutOfRangeException("Uso","El uso de suelo de esta fraccion de autocad no es Válido. Verifica que corresponda a uno de los siguientes valores: 'VE, VS, VP, VM, VR, COM, CS, IND, PAT, SE, AC, RE, EQ, o DON'");
            }
        }
    }
}
