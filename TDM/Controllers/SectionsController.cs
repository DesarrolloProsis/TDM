using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TDM.Models;

namespace TDM.Controllers
{
    public class SectionsController : Controller
    {
        private TDMContext db = new TDMContext();

        // GET: Sections
        public ActionResult Index()
        {
            return View(db.Sections.ToList());
        }

        // GET: Sections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sections sections = db.Sections.Find(id);
            if (sections == null)
            {
                return HttpNotFound();
            }
            return View(sections);
        }

        // GET: Sections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sections/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSection,Nombre")] Sections sections)
        {
            if (ModelState.IsValid)
            {
                db.Sections.Add(sections);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sections);
        }

        // GET: Sections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sections sections = db.Sections.Find(id);
            if (sections == null)
            {
                return HttpNotFound();
            }
            return View(sections);
        }

        // POST: Sections/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSection,Nombre")] Sections sections)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sections).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sections);
        }

        // GET: Sections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sections sections = db.Sections.Find(id);
            if (sections == null)
            {
                return HttpNotFound();
            }
            return View(sections);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sections sections = db.Sections.Find(id);
            db.Sections.Remove(sections);
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
