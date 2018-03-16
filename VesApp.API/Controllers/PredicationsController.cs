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
    public class PredicationsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Predications
        public IQueryable<Predication> GetPredications()
        {
            return db.Predications;
        }

        // GET: api/Predications/5
        [ResponseType(typeof(Predication))]
        public async Task<IHttpActionResult> GetPredication(int id)
        {
            Predication predication = await db.Predications.FindAsync(id);
            if (predication == null)
            {
                return NotFound();
            }

            return Ok(predication);
        }

        // PUT: api/Predications/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPredication(int id, Predication predication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != predication.IdPredication)
            {
                return BadRequest();
            }

            db.Entry(predication).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredicationExists(id))
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

        // POST: api/Predications
        [ResponseType(typeof(Predication))]
        public async Task<IHttpActionResult> PostPredication(Predication predication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Predications.Add(predication);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = predication.IdPredication }, predication);
        }

        // DELETE: api/Predications/5
        [ResponseType(typeof(Predication))]
        public async Task<IHttpActionResult> DeletePredication(int id)
        {
            Predication predication = await db.Predications.FindAsync(id);
            if (predication == null)
            {
                return NotFound();
            }

            db.Predications.Remove(predication);
            await db.SaveChangesAsync();

            return Ok(predication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PredicationExists(int id)
        {
            return db.Predications.Count(e => e.IdPredication == id) > 0;
        }
    }
}