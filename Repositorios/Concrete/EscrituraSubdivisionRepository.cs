using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;

namespace Dixus.Repositorios.Concrete
{
    public class EscrituraSubdivisionRepository : Repository<EscrituraDeSubdivision>, IEscrituraSubdivisionRepository
    {
        public EscrituraSubdivisionRepository(DixusContext context) : base(context)
        {

        }
    }
}
