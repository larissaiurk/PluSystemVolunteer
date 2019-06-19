using PluSystemVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PluSystemVolunteer.Controllers
{
    public class EventoController : Controller
    {
        private Context db = new Context();

        // GET: CategoriaEvento
        public ActionResult Index()
        {
            return View(db.Eventos.ToList());

        }

        // GET: CategoriaEvento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaEvento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventoId")] Evento eventos)
        {
            if (ModelState.IsValid)
            {
                db.Eventos.Add(eventos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventos);
        }
    }
}