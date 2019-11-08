namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarPropTurmasCursosMembrosMatriculas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TurmasCursos", "Turmas_Id", "dbo.Turmas");
            DropForeignKey("dbo.TurmasCursos", "Cursos_Id", "dbo.Cursos");
            DropForeignKey("dbo.Membros", "Turmas_Id", "dbo.Turmas");
            DropIndex("dbo.Membros", new[] { "Turmas_Id" });
            DropIndex("dbo.TurmasCursos", new[] { "Turmas_Id" });
            DropIndex("dbo.TurmasCursos", new[] { "Cursos_Id" });
            CreateIndex("dbo.Matriculas", "MembrosID");
            CreateIndex("dbo.Turmas", "CursosId");
            AddForeignKey("dbo.Matriculas", "MembrosID", "dbo.Membros", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Turmas", "CursosId", "dbo.Cursos", "Id", cascadeDelete: true);
            DropColumn("dbo.Membros", "Turmas_Id");
            DropTable("dbo.TurmasCursos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TurmasCursos",
                c => new
                    {
                        Turmas_Id = c.Int(nullable: false),
                        Cursos_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Turmas_Id, t.Cursos_Id });
            
            AddColumn("dbo.Membros", "Turmas_Id", c => c.Int());
            DropForeignKey("dbo.Turmas", "CursosId", "dbo.Cursos");
            DropForeignKey("dbo.Matriculas", "MembrosID", "dbo.Membros");
            DropIndex("dbo.Turmas", new[] { "CursosId" });
            DropIndex("dbo.Matriculas", new[] { "MembrosID" });
            CreateIndex("dbo.TurmasCursos", "Cursos_Id");
            CreateIndex("dbo.TurmasCursos", "Turmas_Id");
            CreateIndex("dbo.Membros", "Turmas_Id");
            AddForeignKey("dbo.Membros", "Turmas_Id", "dbo.Turmas", "Id");
            AddForeignKey("dbo.TurmasCursos", "Cursos_Id", "dbo.Cursos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TurmasCursos", "Turmas_Id", "dbo.Turmas", "Id", cascadeDelete: true);
        }
    }
}
