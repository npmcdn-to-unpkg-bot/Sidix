using Dixus.BusinessRules.ProyectosDeInversion.Entidades;
using Dixus.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.ProyectosDeInversion
{
    public interface ICalculadoraDeCostosTU
    {
        Task<TuMacronanzanaYDesarrollador> CalcularTuDeFraccion(FraccionVendible fracc);
    }
}
