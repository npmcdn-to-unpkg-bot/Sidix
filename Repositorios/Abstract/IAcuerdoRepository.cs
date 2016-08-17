using Dixus.Entidades;
using System;
using System.Collections.Generic;

namespace Dixus.Repositorios.Abstract
{
    public interface IAcuerdoRepository : IRepository<AcuerdoDeConsejo>
    {

        // Acuerdos
        IEnumerable<AcuerdoDeConsejo> ObtenerAcuerdosMasRecientes(int howmany);
        IEnumerable<AcuerdoDeConsejo> ObtenerAcuerdosQueIncluyanTexto(string textoBuscado);
        IEnumerable<AcuerdoDeConsejo> ObtenerAcuerdosQueIncluyanTextoMasRecientes(string textoBuscado, int howmany);
        
    }
}
