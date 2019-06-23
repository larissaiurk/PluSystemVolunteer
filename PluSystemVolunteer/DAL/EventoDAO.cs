using PluSystemVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PluSystemVolunteer.DAL
{
    public class EventoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static bool CadastrarEvento(Evento evento)
        {
            if (BuscarEventoPorNome(evento) == null)
            {
                ctx.Eventos.Add(evento);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        public static Evento BuscarEventoPorNome(Evento evento)
        {
            return ctx.Eventos.FirstOrDefault(x => x.Descricao.Equals(evento.Descricao));
        }
        public static List<Evento> RetornarEventos()
        {
            return ctx.Eventos.ToList();
        }
        public static Evento BuscarEventoPorId(int? id)
        {
            return ctx.Eventos.Find(id);
        }
        public static void RemoverEvento(Evento evento)
        {
            ctx.Eventos.Remove(evento);
            ctx.SaveChanges();
        }

        public static void AlterarEvento(Evento evento)
        {
            ctx.Entry(evento).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}