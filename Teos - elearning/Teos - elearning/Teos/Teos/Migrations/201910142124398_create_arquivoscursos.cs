namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_arquivoscursos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArquivosCursos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeArquivo = c.String(),
                        Tamanho = c.String(),
                        Extensao = c.String(),
                        CursosID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.CursosID, cascadeDelete: true)
                .Index(t => t.CursosID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArquivosCursos", "CursosID", "dbo.Cursos");
            DropIndex("dbo.ArquivosCursos", new[] { "CursosID" });
            DropTable("dbo.ArquivosCursos");
        }
    }
}
