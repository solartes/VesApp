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