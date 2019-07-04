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

        public static List<ListaPresencaEvento> RetornarListas()
        {
            return ctx.Listas.ToList();
        }

        public static List<ListaPresencaEvento> RetornarListaPresencaPorEvento(int idEvento)
        {
            idEvento = 1;
            return ctx.Listas.Where(x => x.Evento.EventoId.Equals(idEvento)).ToList();
        }

        
        public static bool VerificarAlgoLista(int idUsuario)
        {
            if(ctx.Listas.Where(x => x.Usuario.Equals(idUsuario)).ToList() != null)
            {
                return true;
            }
            else
            {

                return false;
            }
        }


        public static List<ListaPresencaEvento> RetornarInscricoesporIdUsuario(int idUsuario)
        {
            return ctx.Listas.Where(x => x.Usuario.UsuarioId.Equals(idUsuario)).ToList();

        }
    }
}