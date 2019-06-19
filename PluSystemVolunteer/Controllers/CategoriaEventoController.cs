using PluSystemVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PluSystemVolunteer.Controllers
{
    public class CategoriaEventoController : Controller
    {
        private Context db = new Context();

        // GET: CategoriaEvento
        public ActionResult Index()
        { 
          return View(db.CategoriasEvento.ToList());

        }

        // GET: CategoriaEvento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaEvento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaEventoId,Descricao")] CategoriaEvento CategoriaEvento)
        {
            if (ModelState.IsValid)
            {
                db.CategoriasEvento.Add(CategoriaEvento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(CategoriaEvento);
        }

        // GET: CategoriaEvento/Edit/5
        public ActionResult Edit(int? id)
        {
            CategoriaEvento CategoriaEvento = db.CategoriasEvento.Find(id);
            if (CategoriaEvento == null)
            {
                return HttpNotFound();
            }
            return View(CategoriaEvento);
        }

        // POST: CategoriaEvento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaEventoId,Descricao")] CategoriaEvento CategoriaEvento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(CategoriaEvento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(CategoriaEvento);
        }

        // GET: CategoriaEvento/Delete/5
        public ActionResult Delete(int? id)
        {
            CategoriaEvento CategoriaEvento = db.CategoriasEvento.Find(id);
            if (CategoriaEvento == null)
            {
                return HttpNotFound();
            }
            return View(CategoriaEvento);
        }

        // POST: CategoriaEvento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaEvento CategoriaEvento = db.CategoriasEvento.Find(id);
            db.CategoriasEvento.Remove(CategoriaEvento);
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