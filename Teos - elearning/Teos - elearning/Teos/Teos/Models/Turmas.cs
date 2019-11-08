using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class Turmas
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da turma é requirido")]
        public string Nome { get; set; }

        
        public int CursosId { get; set; }
        public virtual ICollection<Matriculas> Matriculas { get; set; }
        
        public virtual Cursos Cursos { get; set; }
    }
}