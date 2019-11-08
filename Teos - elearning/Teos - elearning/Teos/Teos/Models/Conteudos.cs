using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Teos.Models
{
    public class Conteudos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        //O EF colocou essa chave como Not Null, porque?
        public int Avaliacao { get; set; }
        [AllowHtml]
        public string Texto_Embed { get; set; }

        public int Hierarquia { get; set; }

        public int ModulosId { get; set; }

        public string TextoBanner { get; set; }

        public string LinkBanner { get; set;}

        public bool CorTextoBanner { get; set; }

        public string CorFundoBanner { get; set; }

        public virtual Modulos Modulos { get; set; }
        public virtual ICollection<Arquivos> Arquivos { get; set; }
    }
}