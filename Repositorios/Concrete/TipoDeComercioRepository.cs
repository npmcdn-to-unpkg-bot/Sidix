using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;

namespace Dixus.Repositorios.Concrete
{
    public class TipoDeComercioRepository : Repository<TipoDeComercio>, ITipoDeComercioRepository
    {
        public DixusContext DixusContext { get { return Context as DixusContext; } }
        public TipoDeComercioRepository(DixusContext context) : base(context)
        {

        }
    }
}
