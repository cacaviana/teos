using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class WebServicesApi
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public string Basic { get; set; }

        public string TokenAcess { get; set; }

        public virtual ICollection<Credenciais> Credenciais { get; set; }

    }
}