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
        public int GrupoId { get; set; }
        public String Nome { get; set; }
        public int CEP { get; set; }
        public String Endereco { get; set; }
        public int Numero { get; set; }
        public String Complemento { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}