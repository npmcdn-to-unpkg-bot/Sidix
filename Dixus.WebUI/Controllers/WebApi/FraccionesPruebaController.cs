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

namespace Dixus.WebUI.Controllers.WebApi
{
    public class FraccionesPruebaController : ApiController
    {
        private DixusContext db = new DixusContext();

        // GET: api/FraccionesPrueba
        public IEnumerable<Fraccion> GetFracciones()
        {
            return db.Fracciones.Include("TipoDeSuelo");
        }

        // GET: api/FraccionesPrueba/5
        [ResponseType(typeof(Fraccion))]
        public async Task<IHttpActionResult> GetFraccion(int id)
        {
            Fraccion fraccion = await db.Fracciones.FindAsync(id);
            if (fraccion == null)
            {
                return NotFound();
            }

            return Ok(fraccion);
        }

        // PUT: api/FraccionesPrueba/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFraccion(int id, Fraccion fraccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fraccion.FraccionId)
            {
                return BadRequest();
            }

            db.Entry(fraccion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FraccionExists(id))
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

        // POST: api/FraccionesPrueba
        [ResponseType(typeof(Fraccion))]
        public async Task<IHttpActionResult> PostFraccion(Fraccion fraccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fracciones.Add(fraccion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = fraccion.FraccionId }, fraccion);
        }

        // DELETE: api/FraccionesPrueba/5
        [ResponseType(typeof(Fraccion))]
        public async Task<IHttpActionResult> DeleteFraccion(int id)
        {
            Fraccion fraccion = await db.Fracciones.FindAsync(id);
            if (fraccion == null)
            {
                return NotFound();
            }

            db.Fracciones.Remove(fraccion);
            await db.SaveChangesAsync();

            return Ok(fraccion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FraccionExists(int id)
        {
            return db.Fracciones.Count(e => e.FraccionId == id) > 0;
        }
    }
}