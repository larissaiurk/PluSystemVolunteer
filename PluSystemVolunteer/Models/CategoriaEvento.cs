using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PluSystemVolunteer.Models
{
    [Table("CategoriasEvento")]
    public class CategoriaEvento
    {
        [Key]
        public int CategoriaId { get; set; }
        public String Descricao { get; set; }
    }
}