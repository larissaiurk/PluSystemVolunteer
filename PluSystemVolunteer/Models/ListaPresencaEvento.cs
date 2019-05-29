using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PluSystemVolunteer.Models
{
    [Table("ListasPresencaEvento")]
    public class ListaPresencaEvento
    {
        [Key]
        public int ListaPresencaId { get; set; }
        public Evento Evento { get; set; }
        public Usuario Usuario { get; set; }
    }
}