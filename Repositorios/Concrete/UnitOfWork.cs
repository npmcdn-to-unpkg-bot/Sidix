using Dixus.Repositorios.Abstract;
using Dixus.Domain;
using System;
using Dixus.Entidades;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DixusContext _context;
        public UnitOfWork(DixusContext context)
        {
            _context = context;
            Clientes = new ClienteRepository(_context);
            Fracciones = new FraccionRepository(_context);
            TiposDeSuelo = new TipoDeSueloRepository(_context);
            TiposDeComercio = new TipoDeComercioRepository(_context);
            TiposDeInversion = new TipoDeInversionRepository(_context);
            Transacciones = new TransaccionRepository(_context);
            Usuarios = new UserRepository(context);
            Roles = new RoleRepository(context);
            Opciones = new OpcionesRepository(_context);
            SubdivisionesLegales = new FraccionLegalRepository(_context);
            EscriturasDeSubdivision = new EscrituraSubdivisionRepository(_context);
            EscriturasDeTraspaso = new EscrituraTraspasoRepository(_context);
            Juntas = new JuntaRepository(_context);
            Acuerdos = new AcuerdoRepository(_context);
            Tareas = new TareaRepository(_context);
            Vialidades = new VialidadRepository(_context);
            Gis = new GisRepository();
        }
        public UnitOfWork() : this(new DixusContext())
        {
            
        }
        
        public IClienteRepository Clientes { get; private set; }
        public IFraccionRepository Fracciones { get; private set; }
        public ITransaccionRepository Transacciones { get; private set; }
        public ITipoDeSueloRepository TiposDeSuelo { get; private set; }
        public IFraccionLegalRepository SubdivisionesLegales { get; private set; }
        public ITipoDeInversionRepository TiposDeInversion { get; private set; }
        public ITipoDeComercioRepository TiposDeComercio { get; private set; }
        public IUserRepository Usuarios { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public IOpcionesRepository Opciones { get; private set; }
        public IEscrituraSubdivisionRepository EscriturasDeSubdivision { get; private set; }
        public IEscrituraTraspasoRepository EscriturasDeTraspaso { get; private set; }
        public IJuntaRepository Juntas { get; private set;}
        public IAcuerdoRepository Acuerdos { get; private set; }
        public ITareaRepository Tareas { get; private set; }
        public IGisRepository Gis { get; private set; }
        public IVialidadRepository Vialidades { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveToDB()
        {
            return _context.SaveChanges();
        }
    }
}
