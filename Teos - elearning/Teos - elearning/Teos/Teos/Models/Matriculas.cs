using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class Matriculas
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Turmas")]
        public int TurmasId { get; set; }

        //[ForeignKey("Membros")]
        public int MembrosID { get; set; }

        public virtual Usuarios Usuario { get; set; }
        public virtual Turmas Turma { get; set; }
    }
}