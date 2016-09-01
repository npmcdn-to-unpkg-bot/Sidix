using System;
using System.Collections.Generic;
using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using System.Linq;
using Dixus.Entidades.Identity;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Dixus.Repositorios.Concrete
{
    public class VialidadRepository : Repository<Vialidad>, IVialidadRepository
    {
        protected IQueryable<Vialidad> Vialidades;
        public VialidadRepository(DixusContext context) : base(context)
        {
            Vialidades = context.Vialidades.Where(x => x.Descontinuada == false);
        }

        public async Task<IEnumerable<Vialidad>> ObtenerPorNumeroDeCarriles(int numeroDeCarriles)
        {
            return await Vialidades.Where(vial => vial.NumeroDeCarriles == numeroDeCarriles).ToListAsync();
        }
    }
}
