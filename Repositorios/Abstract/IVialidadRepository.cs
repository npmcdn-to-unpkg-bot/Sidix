using Dixus.Entidades;
using Dixus.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Abstract
{
    public interface IVialidadRepository : IRepository<Vialidad>
    {

        Task<IEnumerable<Vialidad>> ObtenerPorNumeroDeCarriles(int numeroDeCarriles); 

    }
}
