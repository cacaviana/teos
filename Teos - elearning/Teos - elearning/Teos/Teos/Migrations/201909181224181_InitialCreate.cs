namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arquivos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL_Arquivo = c.String(nullable: false),
                        ConteudosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conteudos", t => t.ConteudosId, cascadeDelete: true)
                .Index(t => t.ConteudosId);
            
            CreateTable(
                "dbo.Caracteristicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mostra_vitrine = c.Boolean(nullable: false),
                        Permitir_Perguntas = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Conteudos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Avaliacao = c.Int(nullable: false),
                        Texto_Embed = c.String(),
                        ModulosId = c.Int(nullable: false),
                        Cursos_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.Cursos_Id)
                .ForeignKey("dbo.Modulos", t => t.ModulosId, cascadeDelete: true)
                .Index(t => t.ModulosId)
                .Index(t => t.Cursos_Id);
            
            CreateTable(
                "dbo.Convites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TurmasId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Link_Imagem = c.String(),
                        Url_Pg_Vendas = c.String(),
                        Link_Certificado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Membros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        Administrador = c.Boolean(nullable: false),
                        Cursos_Id = c.Int(),
                        Turmas_Id = c.Int(),
                        Perguntas_Id = c.Int(),
                        Respostas_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.Cursos_Id)
                .ForeignKey("dbo.Turmas", t => t.Turmas_Id)
                .ForeignKey("dbo.Perguntas", t => t.Perguntas_Id)
                .ForeignKey("dbo.Respostas", t => t.Respostas_Id)
                .Index(t => t.Cursos_Id)
                .Index(t => t.Turmas_Id)
                .Index(t => t.Perguntas_Id)
                .Index(t => t.Respostas_Id);
            
            CreateTable(
                "dbo.Turmas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CursosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.CursosId, cascadeDelete: true)
                .Index(t => t.CursosId);
            
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TurmasId = c.Int(nullable: false),
                        MembrosID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Turmas", t => t.TurmasId, cascadeDelete: true)
                .Index(t => t.TurmasId);
            
            CreateTable(
                "dbo.Modulos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                        Hierarquia = c.Int(nullable: false),
                        CursosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Perguntas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pergunta = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        MembrosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Respostas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Resposta = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        PerguntasId = c.Int(nullable: false),
                        MembrosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Membros", "Respostas_Id", "dbo.Respostas");
            DropForeignKey("dbo.Membros", "Perguntas_Id", "dbo.Perguntas");
            DropForeignKey("dbo.Conteudos", "ModulosId", "dbo.Modulos");
            DropForeignKey("dbo.Turmas", "CursosId", "dbo.Cursos");
            DropForeignKey("dbo.Membros", "Turmas_Id", "dbo.Turmas");
            DropForeignKey("dbo.Matriculas", "TurmasId", "dbo.Turmas");
            DropForeignKey("dbo.Membros", "Cursos_Id", "dbo.Cursos");
            DropForeignKey("dbo.Conteudos", "Cursos_Id", "dbo.Cursos");
            DropForeignKey("dbo.Arquivos", "ConteudosId", "dbo.Conteudos");
            DropIndex("dbo.Matriculas", new[] { "TurmasId" });
            DropIndex("dbo.Turmas", new[] { "CursosId" });
            DropIndex("dbo.Membros", new[] { "Respostas_Id" });
            DropIndex("dbo.Membros", new[] { "Perguntas_Id" });
            DropIndex("dbo.Membros", new[] { "Turmas_Id" });
            DropIndex("dbo.Membros", new[] { "Cursos_Id" });
            DropIndex("dbo.Conteudos", new[] { "Cursos_Id" });
            DropIndex("dbo.Conteudos", new[] { "ModulosId" });
            DropIndex("dbo.Arquivos", new[] { "ConteudosId" });
            DropTable("dbo.Respostas");
            DropTable("dbo.Perguntas");
            DropTable("dbo.Modulos");
            DropTable("dbo.Matriculas");
            DropTable("dbo.Turmas");
            DropTable("dbo.Membros");
            DropTable("dbo.Cursos");
            DropTable("dbo.Convites");
            DropTable("dbo.Conteudos");
            DropTable("dbo.Caracteristicas");
            DropTable("dbo.Arquivos");
        }
    }
}
