using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class Modulos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]
        public int Hierarquia { get; set; }

        //[ForeignKey("Cursos")]
        public int CursosId { get; set; }

        public virtual Cursos Cursos { get; set; }
        public virtual ICollection<Conteudos> Conteudos { get; set; }
    }
}