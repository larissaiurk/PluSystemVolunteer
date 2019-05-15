using PluSystemVolunteer.DAL;
using PluSystemVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PluSystemVolunteer.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            ViewBag.DataAtual = DateTime.Now;
            ViewBag.Usuarios = UsuarioDAO.RetornarUsuarios();
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(string txtNome, string txtApelido, int txtTelefone)
        {
            Usuario u = new Usuario
            {
                Nome = txtNome,
                Apelido = txtApelido,
                Telefone = txtTelefone,
                DataNascimento = DateTime.Now,
                CriadoEm = DateTime.Now,
                Login = "",
                Senha = ""
            };

            UsuarioDAO.CadastrarUsuario(u);
            return RedirectToAction("Index", "Usuario");
        }

        public ActionResult Remover(int? id)
        {
            UsuarioDAO.RemoverUsuario(UsuarioDAO.BuscarUsuarioPorId(id));
            return RedirectToAction("Index", "Usuario");
        }

        public ActionResult Alterar(int? id)
        {
            ViewBag.Usuario = UsuarioDAO.BuscarUsuarioPorId(id);
            return View();
        }

        [HttpPost]
        public ActionResult Alterar(string txtNome, string txtApelido, int txtTelefone, int hdnId, int txtId)
        {
            Usuario u = UsuarioDAO.BuscarUsuarioPorId(txtId);
            u.Nome = txtNome;
            u.Apelido = txtApelido;
            u.Telefone = txtTelefone;
            u.DataNascimento = DateTime.Now;
            u.CriadoEm = DateTime.Now;
            u.Login = "";
            u.Senha = "";

            UsuarioDAO.AlterarUsuario(u);
            return RedirectToAction("Index", "Usuario");
        }
    }
}