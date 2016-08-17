using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Concrete
{
    public class OpcionesRepository : IOpcionesRepository
    {
        private DixusContext DixusContext { get; set; }
        public OpcionesRepository(DixusContext context)
        {
            DixusContext = context;
        }

        public Opciones Obtener()
        {
            return DixusContext.Opciones.SingleOrDefault();
        }

        public void Update(Opciones opciones)
        {
            DixusContext.Entry(opciones).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
