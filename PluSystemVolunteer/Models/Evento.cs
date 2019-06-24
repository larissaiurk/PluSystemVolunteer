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
        [Display(Name = "Categoria do Evento")]
        public CategoriaEvento CategoriaEvento { get; set; }
        public String Descricao { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public String Complemento { get; set; }
        public Double Preco { get; set; }
        public DateTime Data { get; set; }
        public String Imagem { get; set; }
    }
}