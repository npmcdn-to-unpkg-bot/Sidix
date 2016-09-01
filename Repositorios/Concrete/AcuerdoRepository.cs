using System;
using System.Collections.Generic;
using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using System.Linq;

namespace Dixus.Repositorios.Concrete
{
    public class AcuerdoRepository : Repository<AcuerdoDeConsejo>, IAcuerdoRepository
    {
        public AcuerdoRepository(DixusContext context) : base(context)
        {

        }
        
        public IEnumerable<AcuerdoDeConsejo> ObtenerAcuerdosQueIncluyanTexto(string textoBuscado)
        {
            return EntityQuery.Where(
                acuerdo =>
                    acuerdo.Descripcion.ToLower().Contains(textoBuscado.ToLower()) ||
                    acuerdo.Observaciones.ToLower().Contains(textoBuscado.ToLower())).ToList();
        }
        public IEnumerable<AcuerdoDeConsejo> ObtenerAcuerdosMasRecientes(int howmany)
        {
            return EntityQuery.OrderByDescending(ac => ac.JuntaDeConsejo.Fecha).Take(howmany).ToList();
        }
        public IEnumerable<AcuerdoDeConsejo> ObtenerAcuerdosQueIncluyanTextoMasRecientes(string textoBuscado, int howmany)
        {
            var acuerdosQueIncluyenTexto = EntityQuery.Where(
                acuerdo =>
                    acuerdo.Descripcion.ToLower().Contains(textoBuscado.ToLower()) ||
                    acuerdo.Observaciones.ToLower().Contains(textoBuscado.ToLower()));

            return acuerdosQueIncluyenTexto.OrderByDescending(ac => ac.JuntaDeConsejo.Fecha).ToList();
        }
     
    }
}
