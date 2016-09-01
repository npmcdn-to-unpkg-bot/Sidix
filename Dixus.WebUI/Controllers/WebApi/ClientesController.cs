using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using Dixus.Repositorios.Concrete;

namespace Dixus.WebUI.Controllers.WebApi
{
    public class ClientesController : ApiController
    {
        private IUnitOfWork uow = new UnitOfWork();

        // GET: api/Clientes
        public IEnumerable<Cliente> GetClientes()
        {
            return uow.Clientes.Obtener();
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public async Task<IHttpActionResult> GetCliente(int id)
        {
            Cliente cliente = await uow.Clientes.ObtenerPorIdAsync(cli => cli.ClienteId == id, "Subdivisiones", "ProcesosDeCompraventa");
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }

            uow.Clientes.Update(cliente);

            try
            {
                await uow.SaveToDBAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clientes
        [ResponseType(typeof(Cliente))]
        public async Task<IHttpActionResult> PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            uow.Clientes.Agregar(cliente);
            await uow.SaveToDBAsync();

            return CreatedAtRoute("DefaultApi", new { id = cliente.ClienteId }, cliente);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public async Task<IHttpActionResult> DeleteCliente(int id)
        {
            Cliente cliente = await uow.Clientes.ObtenerPorIdAsync( cli => cli.ClienteId == id );
            if (cliente == null)
            {
                return NotFound();
            }

            uow.Clientes.Borrar(cliente);
            await uow.SaveToDBAsync();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int id)
        {
            return new DixusContext().Clientes.Count(e => e.ClienteId == id) > 0;
        }
    }
}