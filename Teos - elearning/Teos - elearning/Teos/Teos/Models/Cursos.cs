using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class Cursos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do curso é requirido")]
        [DisplayName("Nome do Curso")]
        public string Nome { get; set; }
        public string Promessa { get; set; }

        public string Url_Pg_Vendas { get; set; }
        public string Link_Certificado { get; set; }

        public virtual ICollection<Turmas> Turmas { get; set; }

        public virtual ICollection<Modulos> Modulos { get; set; }
        public virtual ICollection<Usuarios> Membros { get; set; }
        public virtual ICollection<Conteudos> Conteudos { get; set; }
        public virtual ICollection<ArquivosCursos> ArquivosCursos { get; set; }
    }
}