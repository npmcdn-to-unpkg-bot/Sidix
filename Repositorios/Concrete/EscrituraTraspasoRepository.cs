using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;

namespace Dixus.Repositorios.Concrete
{
    public class EscrituraTraspasoRepository : Repository<EscrituraDeTraspaso>, IEscrituraTraspasoRepository
    {
        public EscrituraTraspasoRepository(DixusContext context) : base(context)
        {

        }
    }
}
