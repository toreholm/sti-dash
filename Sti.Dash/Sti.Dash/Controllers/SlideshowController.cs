using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sti.Dash;

namespace Sti.Dash.Controllers
{
    public class SlideshowController : Controller
    {
        private DashboardContext db = new DashboardContext();

        // GET: Slideshow
        public ActionResult Index()
        {
            return View(db.Slideshows.ToList());
        }

        // GET: Slideshow/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slideshow slideshow = db.Slideshows.Find(id);
            if (slideshow == null)
            {
                return HttpNotFound();
            }
            return View(slideshow);
        }

        // GET: Slideshow/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Slideshow/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,text,image")] Slideshow slideshow)
        {
            if (ModelState.IsValid)
            {
                db.Slideshows.Add(slideshow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slideshow);
        }

        // GET: Slideshow/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slideshow slideshow = db.Slideshows.Find(id);
            if (slideshow == null)
            {
                return HttpNotFound();
            }
            return View(slideshow);
        }

        // POST: Slideshow/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,text,image")] Slideshow slideshow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slideshow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slideshow);
        }

        // GET: Slideshow/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slideshow slideshow = db.Slideshows.Find(id);
            if (slideshow == null)
            {
                return HttpNotFound();
            }
            return View(slideshow);
        }

        // POST: Slideshow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slideshow slideshow = db.Slideshows.Find(id);
            db.Slideshows.Remove(slideshow);
            db.SaveChanges();
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
