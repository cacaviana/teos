using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class TurmasViewModel
    {
        public int Codigo_Turma { get; set;}
        public string Nome_Turma { get; set; }
        public string Nome_Curso { get; set; }

        //public DbSet<TurmasViewModel> Turmasctx { get; set; }

    }
}