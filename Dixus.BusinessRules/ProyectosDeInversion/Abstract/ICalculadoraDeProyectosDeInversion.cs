using Dixus.BusinessRules.ProyectosDeInversion.Entidades;
using Dixus.Entidades;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.ProyectosDeInversion
{
    public interface ICalculadoraDeProyectosDeInversion
    {
        Task<InfoCompletaProyectosDeInversion> CalcularDesgloseYTu(FraccionVendible _fraccion);
    }
}
