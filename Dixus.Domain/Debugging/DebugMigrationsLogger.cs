using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Diagnostics;


namespace Dixus.Domain.Debugging
{
    public class DebugMigrationsLogger : MigrationsLogger
    {
        public override void Info(string message)
        {
            Debug.WriteLine(message);
        }
        public override void Verbose(string message)
        {
            Debug.WriteLine(message);
        }
        public override void Warning(string message)
        {
            Debug.WriteLine("WARNING: " + message);
        }
    }
    
    public class MigrationsDebugger
    {
        public bool MigrateDb_Test()
        {
            try
            {
                var config = new Migrations.IdentityConfiguration { AutomaticMigrationDataLossAllowed = true };
                var migrator = new DbMigrator(config);
                var loggingDecorator = new MigratorLoggingDecorator(migrator, new DebugMigrationsLogger());
                loggingDecorator.Update();
                Debug.WriteLine("Paso");
                return true;
            }
            catch (System.Exception)
            {
                Debug.WriteLine("Fallo");
                return false;
            }

        }
    }

   
}
