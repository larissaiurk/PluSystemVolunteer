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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
    }
}