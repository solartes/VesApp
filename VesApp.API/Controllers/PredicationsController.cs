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
            return db.Predications.OrderByDescending(predication => predication.Fecha).Take(14);
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