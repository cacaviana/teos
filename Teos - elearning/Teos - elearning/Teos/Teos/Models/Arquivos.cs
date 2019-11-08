using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class Arquivos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string URL_Arquivo { get; set; }

        public int ConteudosId { get; set; }
    }
}