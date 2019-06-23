using PluSystemVolunteer.DAL;
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
            ViewBag.DataAtual = DateTime.Now;
            return View(CategoriaEventoDAO.RetornarCategoriasEvento());
        }

        // GET: CategoriaEvento/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // GET: CategoriaEvento/Listar
        public ActionResult Listar()
        {
            ViewBag.DataAtual = DateTime.Now;
            //ViewBag.Usuarios = UsuarioDAO.RetornarUsuarios();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CategoriaEvento cat)
        {
           
            if (CategoriaEventoDAO.CadastrarCategoriaEvento(cat))
            {
                return RedirectToAction("Index", "CategoriaEvento");
            }
            return View(cat);
        }

        public ActionResult Remover(int? id)
        {
            CategoriaEventoDAO.RemoverCatEvento(CategoriaEventoDAO.BuscarCatEventoPorId(id));
            return RedirectToAction("Index", "CategoriaEvento");
        }

        public ActionResult Alterar(int? id)
        {
           // ViewBag.Usuario = CategoriaEventoDAO.BuscarCatEventoPorId(id);
            return View(CategoriaEventoDAO.BuscarCatEventoPorId(id));
        }

        [HttpPost]
        public ActionResult Alterar(CategoriaEvento cat)
        {
            CategoriaEvento c = CategoriaEventoDAO.BuscarCatEventoPorId(cat.CategoriaEventoId);
            c.Descricao = cat.Descricao;
            CategoriaEventoDAO.AlterarCategoriaEvento(c);
            return RedirectToAction("Index", "CategoriaEvento");
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