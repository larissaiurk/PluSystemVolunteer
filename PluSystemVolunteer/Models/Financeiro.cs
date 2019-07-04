using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PluSystemVolunteer.Models
{
    [Table("Financeiro")]
    public class Financeiro
    {
        [Key]
        public int FinanceiroId { get; set; }
        public Evento Evento { get; set; }
        public Usuario Usuario { get; set; }
        public string nomeUsuario { get; set; }
        public Double Valor { get; set; }
        public string Descricao { get; set; }
        public bool Credito { get; set; }
    }
}