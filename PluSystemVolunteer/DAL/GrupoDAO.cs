using PluSystemVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PluSystemVolunteer.DAL
{
    public class GrupoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarGrupo (Grupo grup)
        {
            ctx.Grupos.Add(grup);
            ctx.SaveChanges();
        }
        public static List<Grupo> RetornarGrupos()
        {
            return ctx.Grupos.ToList();
        }
        public static Grupo BuscarGrupoPorId(int? id)
        {
            return ctx.Grupos.Find(id);
        }
    }
}