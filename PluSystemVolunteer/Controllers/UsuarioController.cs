﻿using PluSystemVolunteer.DAL;
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
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Web.Services;

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
     
        public static bool captcha = false;

        [HttpPost]
        public ActionResult Login(string txtEmail, string txtSenha)
        {

        
            Usuario u = new Usuario
                {
                    Login = txtEmail,
                    Senha = ComputeSha256Hash(txtSenha)
                };


                Usuario usuario = UsuarioDAO.BuscarUsuarioPorLoginSenha(u);
                if (usuario.Status == true | usuario.Administrador == true)
                {
                    if (usuario != null)
                    {


                        //Cria uma sessão com o usuario e o status de administrador
                        Sessao.Login(usuario.UsuarioId.ToString(), usuario.Administrador);
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["Error"] = "O usuario ou senha estão incorretos, por favor, tente novamente";
                    return RedirectToAction("Login", "Usuario");
                }
                TempData["Error"] = "O administrador precisa validar seu cadastro ainda, aguarde alguns dias e tente novamente!!";
                return RedirectToAction("Login", "Usuario");


        }

        public ActionResult Logout()
        {
            Sessao.ZerarSessao();

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


        public ActionResult Cadastros()
        {
            ViewBag.Usuarios = UsuarioDAO.RetornarUsuarios();

            return View();
        }

        public ActionResult ValidarCadastro(int id)
        {
            Usuario usuario = UsuarioDAO.BuscarUsuarioPorId(id);
            usuario.Status = true;
            UsuarioDAO.AlterarUsuario(usuario);

            return RedirectToAction("Cadastros", "Usuario");

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
                Administrador = false,
                Status = false
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


        public ActionResult Perfil()
        {

            if (Sessao.RetornarUsuario() != 0)
            {

                //eventos


                ViewBag.Eventos = ListaPresencaDAO.RetornarInscricoesporIdUsuario(Sessao.RetornarUsuario());


                //ranking usuarios
                ViewBag.Usuarios = UsuarioDAO.RetornarUsuarios();

                //form
                ViewBag.Usuario = UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario());
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
            }


        [HttpPost]
        public ActionResult Alterar(string txtNome, string txtApelido, string txtTelefone, int hdnId, int txtId, string txtSenha )
        {
            Usuario u = UsuarioDAO.BuscarUsuarioPorId(txtId);
            u.Nome = txtNome;
            u.Apelido = txtApelido;
            u.Telefone = txtTelefone;
            u.DataNascimento = DateTime.Now;
            u.CriadoEm = DateTime.Now;
            if (txtSenha != "") {

                u.Senha = ComputeSha256Hash(txtSenha);
            }

            UsuarioDAO.AlterarUsuario(u);
            return RedirectToAction("Index", "Usuario");
        }

        public ActionResult InscreverEvento(int idEvento, int idUsuario)
        {
            //verifica se existe uma sessão se não volta para a pagina inicial
            if (Sessao.RetornarUsuario() != 0)
            {
                Usuario usuario = UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario());
                usuario.Pontuacao = +1;
                UsuarioDAO.AlterarUsuario(usuario);
                Usuario u = UsuarioDAO.BuscarUsuarioPorId(idUsuario);
                Evento e = EventoDAO.BuscarEventoPorId(idEvento);
                ListaPresencaEvento lista = new ListaPresencaEvento();
                lista.Usuario = u;
                lista.Evento = e;
                if (ListaPresencaDAO.RegistrarInscricaoEvento(lista) == false)
                {
                    TempData["Error"] = "Você já se cadastrou neste evento!!";
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }
        protected static string ReCaptcha_Key = "6Lc7w6kUAAAAAEqeooe_rp5WDpPay0JEM1i28S7S";
        protected static string ReCaptcha_Secret = "6Lc7w6kUAAAAAH9IulqDgACHDl-A0kJOWx04LlJS";

        [WebMethod]
        public static string VerifyCaptcha(string response)
        {

            string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + ReCaptcha_Secret + "&response=" + response;
            
            return (new WebClient()).DownloadString(url);
        }

        

    }
}