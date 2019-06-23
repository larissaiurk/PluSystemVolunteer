using PluSystemVolunteer.DAL;
using PluSystemVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PluSystemVolunteer.Controllers
{
    public class CategoriaEventoController : Controller
    {
        // GET: CategoriaEvento
        public ActionResult Index()
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



    }
}