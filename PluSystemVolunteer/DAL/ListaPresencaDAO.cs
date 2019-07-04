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
            //verifica se existe uma inscrição
            if (BuscarUsuarioeEvento(lista) == null)
            {
                if (lista.Usuario != null && lista.Evento != null)
                {
                    ctx.Listas.Add(lista);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            else
            {
                return false;
             }
        }


        public static ListaPresencaEvento BuscarUsuarioeEvento(ListaPresencaEvento lista)
        {
            return ctx.Listas.FirstOrDefault(x => x.Usuario.UsuarioId.Equals(lista.Usuario.UsuarioId) && x.Evento.EventoId.Equals(lista.Evento.EventoId));
        }
        public static List<ListaPresencaEvento> RetornarListas()
        {
            return ctx.Listas.ToList();
        }

        public static List<ListaPresencaEvento> RetornarListaPresencaPorEvento(int idEvento)
        {
            return ctx.Listas.Where(x => x.Evento.EventoId.Equals(idEvento)).ToList();
        }

        public static ListaPresencaEvento RetornarListaPresencaPorUsuario(int idEvento, int idUsuario)
        {
            return ctx.Listas.FirstOrDefault(x => x.Evento.EventoId.Equals(idEvento) && x.Usuario.UsuarioId.Equals(idUsuario));
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

        public static void CancelarPresenca(int idEvento, int idUsuario)
        {
            ListaPresencaEvento i = RetornarListaPresencaPorUsuario(idEvento, idUsuario);
            if (i != null)
            {
                i.Validada = false;
                ctx.Entry(i).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
            Usuario u = UsuarioDAO.BuscarUsuarioPorId(idUsuario);
            u.Pontuacao -= 1;
            ctx.Entry(u).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void ValidarPresenca(int idEvento, int idUsuario)
        {
            ListaPresencaEvento i = RetornarListaPresencaPorUsuario(idEvento, idUsuario);
            if (i != null)
            {
                i.Validada = true;
                ctx.Entry(i).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
            Usuario u = UsuarioDAO.BuscarUsuarioPorId(idUsuario);
            u.Pontuacao += 1;
            ctx.Entry(u).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}