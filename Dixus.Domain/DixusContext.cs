using Dixus.Entidades;
using Dixus.Entidades.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace Dixus.Domain
{
    public class DixusContext : IdentityDbContext<MyUser, MyRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public DixusContext() 
            :base("name=DixusContext")
        {
            Configuration.LazyLoadingEnabled = false;
            //Database.Log = message => Debug.WriteLine(message);
        }
        public DixusContext(string connectionString) : base(connectionString)
        {
        }

        // Planos
        public virtual DbSet<Fraccion> Fracciones { get; set; }
        public virtual DbSet<Vialidad> Vialidades { get; set; }
        public virtual DbSet<FraccionLegal> FraccionesLegales { get; set; }

        // Financiera
        public virtual DbSet<Ingreso> Ingresos { get; set; }
        public virtual DbSet<Inversion> Inversiones { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }

        // Categorias
        public virtual DbSet<TipoDeSuelo> TiposDeSuelo { get; set; }
        public virtual DbSet<TipoDeComercio> TiposDeComercio { get; set; }

        // Legal
        public virtual DbSet<EscrituraDeSubdivision> EscriturasDeSubdivision { get; set; }
        public virtual DbSet<EscrituraDeTraspaso> EscriturasDeTraspaso { get; set; }

        // Opciones
        public virtual DbSet<Opciones> Opciones { get; set; }
        public virtual DbSet<InfoInversionesEspeciales> InfoInversionesEspeciales { get; set; }

        // Operacion
        public virtual DbSet<JuntaDeConsejo> JuntasDeConsejo { get; set; }
        public virtual DbSet<Tarea> Tareas { get; set; }
        public virtual DbSet<AcuerdoDeConsejo> Acuerdos { get; set; }

        public override int SaveChanges()
        {
            // Marcar la fecha de creacion de las entidades cuando sean añadidas nomás y evitar que sea modificada despues
            foreach (var entry in ChangeTracker.Entries()
                .Where(x => x.Entity.GetType().GetProperty("FechaCreada") != null))
            {
                if (entry.State == EntityState.Added) entry.Property("FechaCreada").CurrentValue = DateTime.Now;
                else if (entry.State == EntityState.Modified) entry.Property("FechaCreada").IsModified = false;
            }

            // Actualizar la fecha de modificacion cuando modifiques una entidad o cuando la añadas
            foreach (var entry in ChangeTracker.Entries()
                .Where( e =>
                    (e.State == EntityState.Modified || e.State == EntityState.Added) && 
                    e.Entity.GetType().GetProperty("UltimaModificacion") != null))
            {
                entry.Property("UltimaModificacion").CurrentValue = DateTime.Now;
            }

            // Marcar como descontinuadas y añadir fecha de descontinuación, en lugar de borrar de verdad, las entidades 'descontinuables' que quieran ser borradas
            foreach ( var entry in ChangeTracker.Entries<EntidadDescontinuable>()
                .Where( x =>
                    x.State == EntityState.Deleted &&
                    x.Entity.GetType().GetProperty("FechaDescontinuada") != null &&
                    x.Entity.GetType().GetProperty("Descontinuada") != null))
            {
                entry.Property("Descontinuada").CurrentValue = true;
                entry.Property("FechaDescontinuada").CurrentValue = DateTime.Now;
                entry.State = EntityState.Modified;
            }

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyUser>()
                .HasMany(u => u.JuntasAsistidas)
                .WithMany(j => j.UsuariosPresentes)
                .Map(x =>
               {
                   x.ToTable("UsuariosEnJuntas");
               });

            modelBuilder.Entity<MyUser>()
                .HasMany(u => u.Tareas)
                .WithMany(j => j.Responsables)
                .Map(x =>
                {
                    x.ToTable("TareasDeUsuarios");
                });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
