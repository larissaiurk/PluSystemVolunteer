using PluSystemVolunteer.DAL;
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
        // GET: Evento
        public ActionResult Index()
        {
            ViewBag.DataAtual = DateTime.Now;
            return View(EventoDAO.RetornarEventos());
        }

        // GET: Evento/Cadastrar
        public ActionResult Cadastrar()
        {
            ViewBag.DataAtual = DateTime.Now;
            ViewBag.Categorias = new SelectList(CategoriaEventoDAO.RetornarCategoriasEvento(), "CategoriaEventoId", "Descricao");
            return View();
        }

        // GET: Evento/Listar
        public ActionResult Listar()
        {
            ViewBag.DataAtual = DateTime.Now;
            ViewBag.Categorias = new SelectList(CategoriaEventoDAO.RetornarCategoriasEvento(), "CategoriaEventoId", "Descricao");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(int? Categorias, HttpPostedFileBase fupImagem, Evento evento)
        {
            evento.Data = DateTime.Now;

            ViewBag.Categorias = new SelectList(CategoriaEventoDAO.RetornarCategoriasEvento(), "CategoriaId", "Nome");
            //Validação das anotações que foram definidas no modelo
            if (ModelState.IsValid)
            {
                evento.CategoriaEvento = CategoriaEventoDAO.BuscarCatEventoPorId(Categorias);
                if (fupImagem != null)
                {
                    string caminho = System.IO.Path.Combine(Server.MapPath("~/Images/"), fupImagem.FileName);
                    fupImagem.SaveAs(caminho);
                    evento.Imagem = fupImagem.FileName;
                }
                else
                {
                    evento.Imagem = "semimg.jpeg";
                }
                if (EventoDAO.CadastrarEvento(evento))
                {
                    return RedirectToAction("Index", "Evento");
                }
                //ModelState.AddModelError("", "Não é possível adicionar um evento com a mesma descrição!");
                return View(evento);
            }
            return View(evento);
        }

        public ActionResult Remover(int? id)
        {
            EventoDAO.RemoverEvento(EventoDAO.BuscarEventoPorId(id));
            return RedirectToAction("Index", "Evento");
        }

        public ActionResult Alterar(int? id)
        {
            // ViewBag.Usuario = CategoriaEventoDAO.BuscarCatEventoPorId(id);
            return View(EventoDAO.BuscarEventoPorId(id));
        }

        [HttpPost]
        public ActionResult Alterar(Evento evento)
        {
            Evento e = EventoDAO.BuscarEventoPorId(evento.EventoId);
            e.Descricao = evento.Descricao;
            EventoDAO.AlterarEvento(evento);
            return RedirectToAction("Index", "Evento");
        }
    }
}