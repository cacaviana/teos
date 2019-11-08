using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class Papeis
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}