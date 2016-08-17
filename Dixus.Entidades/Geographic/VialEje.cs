namespace Dixus.Entidades.Gis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchemaDxs.VialEje")]
    public partial class VialEje
    {
        [Key]
        public long FeatId { get; set; }

        public bool? Ciclovia { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        public bool? ViaCamell { get; set; }

        [StringLength(20)]
        public string ViaCarriles { get; set; }

        [StringLength(20)]
        public string ViaNombre { get; set; }

        [StringLength(20)]
        public string ViaTipo { get; set; }

        [StringLength(20)]
        public string ViaTramo { get; set; }

        public DbGeometry Geom { get; set; }
    }
}
