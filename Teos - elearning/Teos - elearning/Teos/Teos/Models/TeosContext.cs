using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class TeosContext: DbContext
    {
        public TeosContext() : base("TeosBaseFull")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Turmas> Turmas { get; set; }
        public DbSet<Matriculas> Matriculas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Convites> Convites { get; set; }
        public DbSet<Modulos> Modulos { get; set; }
        public DbSet<Conteudos> Conteudos { get; set; }
        public DbSet<Arquivos> Arquivos { get; set; }
        public DbSet<Perguntas> Perguntas { get; set; }
        public DbSet<Respostas> Respostas { get; set; }
        public DbSet<Caracteristicas> Caracteristicas { get; set; }
        public DbSet<Papeis> Papeis { get; set; }
        //Acabei de modificar
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<WebServicesApi> WebServicesApis { get; set; }
        public DbSet<Credenciais> Credenciais { get; set; }
        public DbSet<ArquivosCursos> ArquivosCursos { get; set; }




    }
}