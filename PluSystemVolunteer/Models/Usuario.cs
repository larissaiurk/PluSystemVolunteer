using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PluSystemVolunteer.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public Usuario()
        {
            CriadoEm = new DateTime();
        }

        [Key]
        public int UsuarioId { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        public String Nome { get; set; }
        public String Apelido { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Telefone { get; set; }
        public Boolean Administrador { get; set; }
        public String Imagem { get; set; }
        public Decimal Pontuacao { get; set; }
        //public Grupo Grupo { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}