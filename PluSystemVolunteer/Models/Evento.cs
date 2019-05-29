using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PluSystemVolunteer.Models
{
    [Table("Eventos")]
    public class Evento
    {

        [Key]
        public int EventoId { get; set; }
        public CategoriaEvento CategoriaEvento { get; set; }
        public Grupo Grupo { get; set; }
        public String Descricao { get; set; }
        public String Endereço { get; set; }
        public Double Preco { get; set; }
        public DateTime Data { get; set; }
        public String Imagem { get; set; }
    }
}