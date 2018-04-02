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
using VesApp.Domain;

namespace VesApp.API.Controllers
{
    public class ReflexionsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Reflexions
        public IQueryable<Reflexion> GetReflexions()
        {
            return db.Reflexions.OrderByDescending(reflexion => reflexion.Fecha).Take(14);
        }

        // GET: api/Reflexions/5
        [ResponseType(typeof(Reflexion))]
        public async Task<IHttpActionResult> GetReflexion(int id)
        {
            Reflexion reflexion = await db.Reflexions.FindAsync(id);
            if (reflexion == null)
            {
                return NotFound();
            }

            return Ok(reflexion);
        }

        // PUT: api/Reflexions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReflexion(int id, Reflexion reflexion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reflexion.IdReflexion)
            {
                return BadRequest();
            }

            db.Entry(reflexion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReflexionExists(id))
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

        // POST: api/Reflexions
        [ResponseType(typeof(Reflexion))]
        public async Task<IHttpActionResult> PostReflexion(Reflexion reflexion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reflexions.Add(reflexion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reflexion.IdReflexion }, reflexion);
        }

        // DELETE: api/Reflexions/5
        [ResponseType(typeof(Reflexion))]
        public async Task<IHttpActionResult> DeleteReflexion(int id)
        {
            Reflexion reflexion = await db.Reflexions.FindAsync(id);
            if (reflexion == null)
            {
                return NotFound();
            }

            db.Reflexions.Remove(reflexion);
            await db.SaveChangesAsync();

            return Ok(reflexion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReflexionExists(int id)
        {
            return db.Reflexions.Count(e => e.IdReflexion == id) > 0;
        }
    }
}