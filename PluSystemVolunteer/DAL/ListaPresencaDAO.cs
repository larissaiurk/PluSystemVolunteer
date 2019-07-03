using PluSystemVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PluSystemVolunteer.DAL
{
    public class ListaPresencaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static bool RegistrarInscricaoEvento(ListaPresencaEvento lista)
        {
            if (lista.Usuario != null && lista.Evento !=null)
            {
                ctx.Listas.Add(lista);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}