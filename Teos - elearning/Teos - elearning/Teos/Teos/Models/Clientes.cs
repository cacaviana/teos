using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class Clientes
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereço { get; set; }

        public virtual ICollection<Usuarios> Usuarios {get; set;}
    }
}