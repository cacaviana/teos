using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class Convites
    {
        [Key]
        public int Id { get; set; }

        public int TurmasId { get; set; }

        public virtual Turmas Turmas { get; set; }
    }
}