using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class Perguntas
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Pergunta { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        //[ForeignKey("Membros")]
        public int MembrosId { get; set; }
        public virtual ICollection<Usuarios> Membros { get; set; }
    }
}