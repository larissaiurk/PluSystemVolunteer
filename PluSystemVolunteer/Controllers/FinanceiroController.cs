using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PluSystemVolunteer.Models;

namespace PluSystemVolunteer.Controllers
{
    public class FinanceiroController : Controller
    {
        private Context db = new Context();

        // GET: Financeiro
        public ActionResult Index()
        {
            return View(db.Financeiros.ToList());
        }

        // GET: Financeiro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financeiro financeiro = db.Financeiros.Find(id);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // GET: Financeiro/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FinanceiroId,Valor,Descricao,credito")] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                db.Financeiros.Add(financeiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(financeiro);
        }

        // GET: Financeiro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financeiro financeiro = db.Financeiros.Find(id);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FinanceiroId,Valor,Descricao,credito")] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(financeiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(financeiro);
        }

        // GET: Financeiro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financeiro financeiro = db.Financeiros.Find(id);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // POST: Financeiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Financeiro financeiro = db.Financeiros.Find(id);
            db.Financeiros.Remove(financeiro);
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
