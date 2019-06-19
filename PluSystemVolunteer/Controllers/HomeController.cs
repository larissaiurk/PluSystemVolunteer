using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PluSystemVolunteer.DAL;

namespace PluSystemVolunteer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                ViewBag.Usuarios = UsuarioDAO.RetornarUsuarios();

                return View();

            }
            return View();
        }
    }
}