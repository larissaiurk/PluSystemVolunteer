using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PluSystemVolunteer.DAL;
using PluSystemVolunteer.utils;

namespace PluSystemVolunteer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Sessao.RetornarUsuario() != 0)
            {
                //eventos
                     ViewBag.Eventos = EventoDAO.RetornarEventos();
                //ranking usuarios
                    ViewBag.Usuarios = UsuarioDAO.RetornarUsuariosPorPontuacao();

                    return View();

            
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }
    }
           
}