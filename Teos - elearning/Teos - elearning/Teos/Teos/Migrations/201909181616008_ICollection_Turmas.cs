namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ICollection_Turmas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Turmas", "CursosId", "dbo.Cursos");
            DropIndex("dbo.Turmas", new[] { "CursosId" });
            CreateTable(
                "dbo.TurmasCursos",
                c => new
                    {
                        Turmas_Id = c.Int(nullable: false),
                        Cursos_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Turmas_Id, t.Cursos_Id })
                .ForeignKey("dbo.Turmas", t => t.Turmas_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cursos", t => t.Cursos_Id, cascadeDelete: true)
                .Index(t => t.Turmas_Id)
                .Index(t => t.Cursos_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TurmasCursos", "Cursos_Id", "dbo.Cursos");
            DropForeignKey("dbo.TurmasCursos", "Turmas_Id", "dbo.Turmas");
            DropIndex("dbo.TurmasCursos", new[] { "Cursos_Id" });
            DropIndex("dbo.TurmasCursos", new[] { "Turmas_Id" });
            DropTable("dbo.TurmasCursos");
            CreateIndex("dbo.Turmas", "CursosId");
            AddForeignKey("dbo.Turmas", "CursosId", "dbo.Cursos", "Id", cascadeDelete: true);
        }
    }
}
