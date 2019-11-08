using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class ArquivosCursos
    {
        public int Id { get; set; }
        public string NomeArquivo { get; set; }
        public string Tamanho { get; set; }
        public string Extensao { get; set; }
        public int CursosID { get; set; }

        public virtual Cursos Cursos { get; set;}

    }
}