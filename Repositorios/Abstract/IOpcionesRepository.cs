using Dixus.Entidades;

namespace Dixus.Repositorios.Abstract
{
    public interface IOpcionesRepository
    {
        Opciones Obtener();
        void Update(Opciones opciones); 

    }

    
}
