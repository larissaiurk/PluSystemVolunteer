using PluSystemVolunteer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PluSystemVolunteer.Controllers
{
    public class ListaPresencaController : Controller
    {
        // GET: ListaPresenca
        public ActionResult Index(int idEvento)
        {
            return View(ListaPresencaDAO.RetornarListaPresencaPorEvento(idEvento));
        }

        public ActionResult CancelarPresenca(int idEvento, int idUsuario)
        {
            ListaPresencaDAO.CancelarPresenca(idEvento, idUsuario);
            return RedirectToAction("Index", "ListaPresenca", new { idEvento = idEvento });
        }

        public ActionResult ValidarPresenca(int idEvento, int idUsuario)
        {
            ListaPresencaDAO.ValidarPresenca(idEvento, idUsuario);
            return RedirectToAction("Index", "ListaPresenca", new { idEvento = idEvento});
        }
    }
}