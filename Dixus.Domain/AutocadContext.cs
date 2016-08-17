namespace Dixus.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entidades.Gis;
    public partial class AutocadContext : DbContext
    {
        public AutocadContext()
            : base("name=AutocadContext")
        {
        }

        public virtual DbSet<FeatureFraccion> Fracciones { get; set; }
        public virtual DbSet<VialEje> VialidadesEjes { get; set; }
        public virtual DbSet<VialPoly> VialidadesPoligonos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
