using PluSystemVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PluSystemVolunteer.DAL
{
    public class CategoriaEventoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static bool CadastrarCategoriaEvento(CategoriaEvento cat)
        {
            if (BuscarCategoriaPorNome(cat) == null)
            {
                ctx.CategoriasEvento.Add(cat);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        public static CategoriaEvento BuscarCategoriaPorNome(CategoriaEvento cat)
        {
            return ctx.CategoriasEvento.FirstOrDefault(x => x.Descricao.Equals(cat.Descricao));
        }
        public static List<CategoriaEvento> RetornarCategoriasEvento()
        {
            return ctx.CategoriasEvento.ToList();
        }
        public static CategoriaEvento BuscarCatEventoPorId(int? id)
        {
            return ctx.CategoriasEvento.Find(id);
        }
        public static void RemoverCatEvento(CategoriaEvento cat)
        {
            ctx.CategoriasEvento.Remove(cat);
            ctx.SaveChanges();
        }

        public static void AlterarCategoriaEvento(CategoriaEvento cat)
        {
            ctx.Entry(cat).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}