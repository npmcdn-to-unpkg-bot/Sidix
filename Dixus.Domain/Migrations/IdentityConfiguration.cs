namespace Dixus.Domain.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Dixus.Entidades.Identity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using Microsoft.AspNet.Identity;
    using Entidades;
    using Microsoft.AspNet.Identity.EntityFramework;
    internal sealed class IdentityConfiguration : DbMigrationsConfiguration<DixusContext>
    {
        private MyUserManager _usermanager;
        private MyRoleManager _rolemanager;
        private MigrationsSeedProvider _migrationsProvider;
        public IdentityConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DixusContext context)
        {
            _usermanager = new MyUserManager(context);
            _rolemanager = new MyRoleManager(context);
            _migrationsProvider = new MigrationsSeedProvider(_usermanager);

            try {
                //Crear roles, si no existen
                foreach (var roleAAgregar in _migrationsProvider.ObtenerRoles())
                {
                    if (!context.Roles.Any(r => r.Name == roleAAgregar.Name))
                        _rolemanager.Create(roleAAgregar);
                }

                // Crear usuarios, si no existen
                foreach (var usuarioAAgregar in _migrationsProvider.ObtenerUsuarios())
                {
                    if (!context.Users.Any(u => u.UserName == usuarioAAgregar.UserName))
                        _usermanager.Create(usuarioAAgregar);
                }

                // Añadir los usuarios a sus roles correspondientes
                AgregarRolesAUsuarios();

                // Anadir demás entidades
                AnadirEntidadesDixusADB(context);
                
                // Anadir relaciones many-to-many
                AñadirUsuariosATareas(context);
                AñadirUsuariosAJuntas(context);

                // Guardar cambios
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx) {
                foreach (var validationErrors in dbEx.EntityValidationErrors) {
                    foreach (var validationError in validationErrors.ValidationErrors) {
                        Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

        }

        
        // METODOS AUXILIARES PARA EL PRINCIPAL 'SEED'
        private void AnadirEntidadesDixusADB(DixusContext context)
        {
            context.Vialidades.AddOrUpdate(vial => vial.VialidadId, _migrationsProvider.ObtenerVialidades());
            context.JuntasDeConsejo.AddOrUpdate(jun => jun.JuntaDeConsejoId, _migrationsProvider.ObtenerJuntas());
            context.TiposDeSuelo.AddOrUpdate(suelo => suelo.TipoDeSueloId, _migrationsProvider.ObtenerTiposDeSuelo());
            context.Inversiones.AddOrUpdate(inv => inv.TransaccionID, _migrationsProvider.ObtenerInversiones());
            context.Clientes.AddOrUpdate(cliente => cliente.ClienteId, _migrationsProvider.ObtenerClientes());
            context.TiposDeComercio.AddOrUpdate(x => x.TipoDeComercioId, _migrationsProvider.ObtenerTiposDeComercio());
            context.Opciones.AddOrUpdate(x => x.OpcionesId, _migrationsProvider.ObtenerOpciones());
            context.Acuerdos.AddOrUpdate(x => x.AcuerdoDeConsejoId, _migrationsProvider.ObtenerAcuerdos());
            context.EscriturasDeSubdivision.AddOrUpdate(x => x.NumDeSubdivision, _migrationsProvider.ObtenerEscriturasDeSubdivision());
            context.InfoInversionesEspeciales.AddOrUpdate(x => x.Id, _migrationsProvider.ObtenerInversionesEspeciales());
            context.Tareas.AddOrUpdate(x => x.TareaId, _migrationsProvider.ObtenerTareas());
            context.FraccionesLegales.AddOrUpdate(x => x.FraccionLegalId, _migrationsProvider.ObtenerSubdivisionesLegales());

            // Se tienen que grabar los cambios antes de añadir las fracciones para que estas puedan hacer la validacion de la clase del tipodesuelo
            context.SaveChanges();
            context.Fracciones.AddOrUpdate(x => x.FraccionId, _migrationsProvider.ObtenerFracciones());


        }

        private void AñadirUsuariosAJuntas(DixusContext context)
        {
            MyUser chato = context.Users.Single(us => us.UserName == "Chatopaniagua");
            MyUser cecy = context.Users.Single(us => us.UserName == "CGarcia");
            MyUser fabian = context.Users.Single(us => us.UserName == "FIriarte");
            MyUser mirna = context.Users.Single(us => us.UserName == "MQuintanilla");
            MyUser chamundo = context.Users.Single(us => us.UserName == "RaymundoGDL");
            MyUser tana = context.Users.Single(us => us.UserName == "FernandoGDL");
            MyUser memo = context.Users.Single(us => us.UserName == "Guillermoulloa");
            MyUser tono = context.Users.Single(us => us.UserName == "MGDL");

            var juntaPresentacionSidix = context.JuntasDeConsejo.Include("UsuariosPresentes").Single(x=>x.JuntaDeConsejoId == 1);
            juntaPresentacionSidix.UsuariosPresentes.Add(cecy);
            juntaPresentacionSidix.UsuariosPresentes.Add(chato);
            juntaPresentacionSidix.UsuariosPresentes.Add(tono);

            var juntaAvancesSidix = context.JuntasDeConsejo.Include("UsuariosPresentes").Single(x => x.JuntaDeConsejoId == 2);
            juntaAvancesSidix.UsuariosPresentes.Add(tono);
            juntaAvancesSidix.UsuariosPresentes.Add(chato);
            juntaAvancesSidix.UsuariosPresentes.Add(tana);

            var juntaConsejoDixus = context.JuntasDeConsejo.Include("UsuariosPresentes").Single(x => x.JuntaDeConsejoId == 3);
            juntaConsejoDixus.UsuariosPresentes.Add(tono);
            juntaConsejoDixus.UsuariosPresentes.Add(tana);
            juntaConsejoDixus.UsuariosPresentes.Add(chamundo);
            juntaConsejoDixus.UsuariosPresentes.Add(cecy);
            juntaConsejoDixus.UsuariosPresentes.Add(memo);

            var juntaConsejoVintel = context.JuntasDeConsejo.Include("UsuariosPresentes").Single(x => x.JuntaDeConsejoId == 4);
            juntaConsejoVintel.UsuariosPresentes.Add(tono);
            juntaConsejoVintel.UsuariosPresentes.Add(cecy);

            var juntaNavidad = context.JuntasDeConsejo.Include("UsuariosPresentes").Single(x => x.JuntaDeConsejoId == 5);
            juntaNavidad.UsuariosPresentes.Add(tono);
            juntaNavidad.UsuariosPresentes.Add(cecy);
            juntaNavidad.UsuariosPresentes.Add(chamundo);

            var juntaConsejoEvalorem = context.JuntasDeConsejo.Include("UsuariosPresentes").Single(x => x.JuntaDeConsejoId == 6);
            juntaConsejoEvalorem.UsuariosPresentes.Add(cecy);
            juntaConsejoEvalorem.UsuariosPresentes.Add(tono);
            juntaConsejoEvalorem.UsuariosPresentes.Add(chamundo);
            juntaConsejoEvalorem.UsuariosPresentes.Add(tana);

            var juntaOperativaVintel = context.JuntasDeConsejo.Include("UsuariosPresentes").Single(x => x.JuntaDeConsejoId == 7);
            juntaOperativaVintel.UsuariosPresentes.Add(tono);
            juntaOperativaVintel.UsuariosPresentes.Add(cecy);

            var juntaOperativaEvalorem = context.JuntasDeConsejo.Include("UsuariosPresentes").Single(x => x.JuntaDeConsejoId == 8);
            juntaOperativaEvalorem.UsuariosPresentes.Add(cecy);
            juntaOperativaEvalorem.UsuariosPresentes.Add(tono);
            juntaOperativaEvalorem.UsuariosPresentes.Add(chamundo);
            juntaOperativaEvalorem.UsuariosPresentes.Add(tana);

            var juntaConsejoPrimavera = context.JuntasDeConsejo.Include("UsuariosPresentes").Single(x => x.JuntaDeConsejoId == 9);
            juntaConsejoPrimavera.UsuariosPresentes.Add(chato);
            juntaConsejoPrimavera.UsuariosPresentes.Add(cecy);

        }

        private void AñadirUsuariosATareas(DixusContext context)
        {
            MyUser chato = context.Users.Single(us => us.UserName == "Chatopaniagua");
            MyUser cecy = context.Users.Single(us => us.UserName == "CGarcia");
            MyUser fabian = context.Users.Single(us => us.UserName == "FIriarte");
            MyUser mirna = context.Users.Single(us => us.UserName == "MQuintanilla");

            var subdividirFraccion = context.Tareas.OfType<ProcesoDeSubdivision>().Include("Responsables").First();
            subdividirFraccion.Responsables.Add(chato);
            subdividirFraccion.Responsables.Add(cecy);

            var mejorarMenu = context.Tareas.OfType<TareaBinaria>().Include("Responsables").First();
            mejorarMenu.Responsables.Add(chato);

            var definirProtocolos = context.Tareas.OfType<TareaDePorcentaje>().Include("Responsables").First();
            definirProtocolos.Responsables.Add(cecy);

            var hacerCompraventa = context.Tareas.OfType<ProcesoDeCompraventa>().Include("Responsables").First();
            hacerCompraventa.Responsables.Add(fabian);
            hacerCompraventa.Responsables.Add(mirna);
        }

        private void AgregarRolesAUsuarios()
        {
            MyUser[] usuarios = _migrationsProvider.ObtenerUsuarios();
            _usermanager.AddToRoles(usuarios.Single(u => u.UserName == "Chatopaniagua").Id, "Administrador", "Técnico", "Legal", "Ventas");
            _usermanager.AddToRoles(usuarios.Single(u => u.UserName == "Guillermoulloa").Id,"Administrador", "Técnico");
            _usermanager.AddToRoles(usuarios.Single(u => u.UserName == "RaymundoGDL").Id,   "Administrador", "Ventas");
            _usermanager.AddToRoles(usuarios.Single(u => u.UserName == "FernandoGDL").Id,   "Administrador", "Ventas");
            _usermanager.AddToRoles(usuarios.Single(u => u.UserName == "CGarcia").Id,       "Administrador");
            _usermanager.AddToRoles(usuarios.Single(u => u.UserName == "MGDL").Id,          "Administrador");
            _usermanager.AddToRoles(usuarios.Single(u => u.UserName == "MQuintanilla").Id,  "Legal");
            _usermanager.AddToRoles(usuarios.Single(u => u.UserName == "FIriarte").Id,      "Técnico");
        }

    }
}
