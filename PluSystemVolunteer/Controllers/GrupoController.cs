using PluSystemVolunteer.DAL;
using PluSystemVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PluSystemVolunteer.Controllers
{
    public class GrupoController : Controller
    {
        private Context db = new Context();
        // GET: Grupo
        public ActionResult Index()
        {
            return View(db.Grupos.ToList());
        }

        // GET: Grupo/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(HttpPostedFileBase fupImagem, Grupo grupo)
        {

            if (ModelState.IsValid)
            {
                grupo.CriadoEm = DateTime.Now;
                if (GrupoDAO.CadastrarGrupo(grupo))
                {
                    return RedirectToAction("Index", "Grupo");
                }
                //Retornar uma mensagem para view
                ModelState.AddModelError("", "Não é possível adicionar um grupo com o mesmo nome!");
                return View(grupo);
            }
            return View(grupo);
        }
    }
}