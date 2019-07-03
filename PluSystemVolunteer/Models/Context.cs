using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PluSystemVolunteer.Models
{
    public class Context : DbContext
    {
        public Context() : base("DbPluSystemVolunteer") { }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CategoriaEvento> CategoriasEvento { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<ListaPresencaEvento> Listas { get; set; }
    }
}