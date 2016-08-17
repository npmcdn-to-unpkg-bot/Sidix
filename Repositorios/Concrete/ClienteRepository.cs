using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;

namespace Dixus.Repositorios.Concrete
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public DixusContext DixusContext { get { return Context as DixusContext; } }
        public ClienteRepository(DixusContext context) : base(context)
        {

        }
    }
}
