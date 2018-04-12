using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VesApp.Backend.Models;
using VesApp.Domain;

namespace VesApp.Backend.Controllers
{
    public class PredicationsController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Predications
        public async Task<ActionResult> Index()
        {
            return View(await db.Predications.OrderByDescending(predication => predication.Fecha).ToListAsync());
        }

        // GET: Predications/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predication predication = await db.Predications.FindAsync(id);
            if (predication == null)
            {
                return HttpNotFound();
            }
            return View(predication);
        }

        // GET: Predications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Predications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPredication,Titulo,Text,UrlVideo,UrlImagen,Fecha,Sacerdote")] Predication predication)
        {
            if (ModelState.IsValid)
            {
                if (predication.UrlImagen == null)
                {
                    string urlVideo = predication.UrlVideo;
                    int index = urlVideo.LastIndexOf('/');
                    String idVideo = urlVideo.Substring(index + 1);
                    String urlImagen = "https://img.youtube.com/vi/" + idVideo + "/0.jpg";
                    predication.UrlImagen = urlImagen;
                }
                db.Predications.Add(predication);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }            
            return View(predication);
        }

        // GET: Predications/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predication predication = await db.Predications.FindAsync(id);
            if (predication == null)
            {
                return HttpNotFound();
            }
            return View(predication);
        }

        // POST: Predications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPredication,Titulo,Text,UrlVideo,UrlImagen,Fecha,Sacerdote")] Predication predication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predication).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(predication);
        }

        // GET: Predications/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predication predication = await db.Predications.FindAsync(id);
            if (predication == null)
            {
                return HttpNotFound();
            }
            return View(predication);
        }

        // POST: Predications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Predication predication = await db.Predications.FindAsync(id);
            db.Predications.Remove(predication);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
