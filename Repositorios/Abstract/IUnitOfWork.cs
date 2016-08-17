using Dixus.Entidades;
using System;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository Clientes { get; }
        IFraccionRepository Fracciones { get; }
        IFraccionLegalRepository SubdivisionesLegales { get; }
        ITipoDeSueloRepository TiposDeSuelo { get; }
        ITransaccionRepository Transacciones { get; }
        ITipoDeInversionRepository TiposDeInversion { get; }
        ITipoDeComercioRepository TiposDeComercio { get; }
        IUserRepository Usuarios { get; }
        IRoleRepository Roles { get; }
        IOpcionesRepository Opciones { get; }
        IEscrituraSubdivisionRepository EscriturasDeSubdivision { get; }
        IEscrituraTraspasoRepository EscriturasDeTraspaso { get; }
        IJuntaRepository Juntas { get; }
        IAcuerdoRepository Acuerdos { get; }
        ITareaRepository Tareas { get; }
        IGisRepository Gis { get; }
        IVialidadRepository Vialidades { get; }
        int SaveToDB();
    }
}
