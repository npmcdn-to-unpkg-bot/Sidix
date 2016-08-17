using System.Collections.Generic;
using Dixus.Entidades;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Abstract
{
    public interface IFraccionLegalRepository : IRepository<FraccionLegal>
    {
        //IEnumerable<FraccionLegal> ObtenerFraccionesComoEstabanEnFecha(DateTime fecha);

        Task<IEnumerable<FraccionLegal>> ObtenerMasGrandes(int howmany);
        Task<IEnumerable<FraccionLegal>> ObtenerMasChicas(int howmany);
        Task<IEnumerable<FraccionLegal>> ObtenerPorCliente(int clienteid);

        Task<double> AreaTotal();
        Task<double> AreaPorCliente(int clienteid);
    }
}
