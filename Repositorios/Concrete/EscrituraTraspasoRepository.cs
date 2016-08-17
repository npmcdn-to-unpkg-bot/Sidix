using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;

namespace Dixus.Repositorios.Concrete
{
    public class EscrituraTraspasoRepository : Repository<EscrituraDeTraspaso>, IEscrituraTraspasoRepository
    {
        public DixusContext DixusContext { get { return Context as DixusContext; } }
        public EscrituraTraspasoRepository(DixusContext context) : base(context)
        {

        }
    }
}
