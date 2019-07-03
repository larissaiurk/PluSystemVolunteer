using PluSystemVolunteer.DAL;
using PluSystemVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PluSystemVolunteer.utils;


namespace PluSystemVolunteer.Controllers
{
    public class UsuarioController : Controller
    {

        SHA256 shaM = new SHA256Managed();


        //encryptador de strings
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        // GET: Usuario
        public ActionResult Index()
        {
            ViewBag.DataAtual = DateTime.Now;
            ViewBag.Usuarios = UsuarioDAO.RetornarUsuarios();
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(string txtEmail, string txtSenha)
        {
            Usuario u = new Usuario
            {
                Login = txtEmail,
                Senha = ComputeSha256Hash(txtSenha)
            };

      
            Usuario usuario = UsuarioDAO.BuscarUsuarioPorLoginSenha(u);
            if(usuario != null)
            {
              

                //Cria uma sessão com o usuario e o status de administrador
                Sessao.Login(usuario.UsuarioId.ToString(), usuario.Administrador);
                ViewBag.idUsuario = Sessao.RetornarUsuario();
                ViewBag.admin     = Sessao.RetornarStatus();

                return RedirectToAction("Index", "Home");
            }
            TempData["Error"] = "O usuario ou senha estão incorretos, por favor, tente novamente";
            return RedirectToAction("Login", "Usuario");

        }

        public ActionResult Listar()
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

        public ActionResult Cadastrar(string txtNome, string txtTelefone, string txtEmail, string txtSenha)
        {
            Usuario u = new Usuario
            {

                Nome = txtNome,
                //Apelido = txtApelido,
                Telefone = txtTelefone,
                DataNascimento = DateTime.Now,
                CriadoEm = DateTime.Now,
                Login = txtEmail,
                Senha = ComputeSha256Hash(txtSenha),
                Administrador = false
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
        public ActionResult Alterar(string txtNome, string txtApelido, string txtTelefone, int hdnId, int txtId)
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

        public ActionResult InscreverEvento(int idEvento, int idUsuario)
        {
            //verifica se existe uma sessão se não volta para a pagina inicial
            if (Sessao.RetornarUsuario() != 0)
            {
                 Usuario u = UsuarioDAO.BuscarUsuarioPorId(idUsuario);
                Evento e = EventoDAO.BuscarEventoPorId(idEvento);
                ListaPresencaEvento lista = new ListaPresencaEvento();
                lista.Usuario = u;
                lista.Evento = e;
                ListaPresencaDAO.RegistrarInscricaoEvento(lista);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

    }
}