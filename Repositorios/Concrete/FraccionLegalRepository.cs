using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Dixus.Repositorios.Abstract;
using Dixus.Entidades;
using Dixus.Domain;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Concrete
{
    public class FraccionLegalRepository : Repository<FraccionLegal>, IFraccionLegalRepository
    {
        protected IQueryable<FraccionLegal> Subdivisiones;
        public FraccionLegalRepository(DixusContext context) : base(context)
        {
            Subdivisiones = context.FraccionesLegales.Where(sub => sub.Descontinuada == false);
        }

        public async Task<IEnumerable<FraccionLegal>> ObtenerMasGrandes(int howmany)
        {
            return await Subdivisiones
               .OrderByDescending(x => x.Superficie)
               .Take(howmany)
               .ToListAsync();
        }
        public async Task<IEnumerable<FraccionLegal>> ObtenerMasChicas(int howmany)
        {
            return await Subdivisiones
               .OrderBy(x => x.Superficie)
               .Take(howmany)
               .ToListAsync();
        }
        public async Task<IEnumerable<FraccionLegal>> ObtenerPorCliente(int clienteid)
        {
            return await Subdivisiones
                .Where(sub =>
                    sub.Clientes != null &&
                    sub.Clientes.Count > 0 &&
                    sub.Clientes.Any(cli => cli.ClienteId == clienteid))
                .ToListAsync();
        }

        public async Task<double> AreaTotal()
        {
            return await Subdivisiones
                .SumAsync(x => x.Superficie);
        }
        public async Task<double> AreaPorCliente(int clienteid)
        {
            return await Subdivisiones
                .Where(sub =>
                    sub.Clientes != null &&
                    sub.Clientes.Count > 0 &&
                    sub.Clientes.Any(cli => cli.ClienteId == clienteid))
                .SumAsync(sub => sub.Superficie);
        }
    }

}
