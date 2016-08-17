namespace Dixus.Entidades.Gis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchemaDxs.VialPoly")]
    public partial class VialPoly
    {
        [Key]
        public long FeatId { get; set; }

        [StringLength(20)]
        public string ViaNombre { get; set; }

        [StringLength(20)]
        public string ViaTramo { get; set; }

        public DbGeometry Geom { get; set; }
    }
}
