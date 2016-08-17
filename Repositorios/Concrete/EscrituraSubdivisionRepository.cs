using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;

namespace Dixus.Repositorios.Concrete
{
    public class EscrituraSubdivisionRepository : Repository<EscrituraDeSubdivision>, IEscrituraSubdivisionRepository
    {
        public DixusContext DixusContext { get { return Context as DixusContext; } }
        public EscrituraSubdivisionRepository(DixusContext context) : base(context)
        {

        }
    }
}
