using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teos.Models.DTO
{
    public class CursosApi
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string URL { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int CargaHoraria { get; set; }
    }
}