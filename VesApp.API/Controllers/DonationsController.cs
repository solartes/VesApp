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
    public class DonationsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Donations
        public IQueryable<Donation> GetDonations()
        {
            return db.Donations;
        }

        // GET: api/Donations/5
        [ResponseType(typeof(Donation))]
        public async Task<IHttpActionResult> GetDonation(int id)
        {
            Donation donation = await db.Donations.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }

            return Ok(donation);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonationExists(int id)
        {
            return db.Donations.Count(e => e.IdDonation == id) > 0;
        }
    }
}