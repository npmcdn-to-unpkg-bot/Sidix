using Dixus.Repositorios.Abstract;
using Dixus.Entidades;
using Dixus.Domain;

namespace Dixus.Repositorios.Concrete
{
    public class TipoDeSueloRepository : Repository<TipoDeSuelo>, ITipoDeSueloRepository
    {
        public TipoDeSueloRepository(DixusContext context) : base(context)
        {

        }
    }
}
