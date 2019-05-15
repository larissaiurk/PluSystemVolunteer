using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PluSystemVolunteer.Models
{
    [Table("Grupos")]
    public class Grupo
    {
        public Grupo()
        {
            CriadoEm = new DateTime();
        }

        [Key]
        public int UsuarioId { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}