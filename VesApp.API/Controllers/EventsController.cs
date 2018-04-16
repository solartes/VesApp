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
    public class EventsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Events
        public IQueryable<Event> GetEvents()
        {
            return db.Events.OrderByDescending(evento => evento.FechaEvento).Take(14);            
        }

        // GET: api/Events/5
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> GetEvent(int id)
        {
            Event @event = await db.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int id)
        {
            return db.Events.Count(e => e.IdEvent == id) > 0;
        }
    }
}