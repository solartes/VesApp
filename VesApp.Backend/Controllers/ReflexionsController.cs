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
    public class ReflexionsController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Reflexions
        public async Task<ActionResult> Index()
        {
            return View(await db.Reflexions.ToListAsync());
        }

        // GET: Reflexions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reflexion reflexion = await db.Reflexions.FindAsync(id);
            if (reflexion == null)
            {
                return HttpNotFound();
            }
            return View(reflexion);
        }

        // GET: Reflexions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reflexions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdReflexion,Titulo,Text,UrlVideo,UrlImagen,Fecha,Sacerdote")] Reflexion reflexion)
        {
            if (ModelState.IsValid)
            {
                db.Reflexions.Add(reflexion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(reflexion);
        }

        // GET: Reflexions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reflexion reflexion = await db.Reflexions.FindAsync(id);
            if (reflexion == null)
            {
                return HttpNotFound();
            }
            return View(reflexion);
        }

        // POST: Reflexions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdReflexion,Titulo,Text,UrlVideo,UrlImagen,Fecha,Sacerdote")] Reflexion reflexion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reflexion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reflexion);
        }

        // GET: Reflexions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reflexion reflexion = await db.Reflexions.FindAsync(id);
            if (reflexion == null)
            {
                return HttpNotFound();
            }
            return View(reflexion);
        }

        // POST: Reflexions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reflexion reflexion = await db.Reflexions.FindAsync(id);
            db.Reflexions.Remove(reflexion);
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
