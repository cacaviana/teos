namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarMembrosparaUsuarioeCriarentidadePapeis : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Membros", newName: "Usuarios");
            DropForeignKey("dbo.Matriculas", "MembrosID", "dbo.Membros");
            DropIndex("dbo.Matriculas", new[] { "MembrosID" });
            CreateTable(
                "dbo.Papeis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Usuarios", "SobreNome", c => c.String());
            AddColumn("dbo.Matriculas", "Membro_Id", c => c.Int());
            CreateIndex("dbo.Matriculas", "Membro_Id");
            AddForeignKey("dbo.Matriculas", "Membro_Id", "dbo.Usuarios", "Id");
            DropColumn("dbo.Usuarios", "Administrador");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Administrador", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Matriculas", "Membro_Id", "dbo.Usuarios");
            DropIndex("dbo.Matriculas", new[] { "Membro_Id" });
            DropColumn("dbo.Matriculas", "Membro_Id");
            DropColumn("dbo.Usuarios", "SobreNome");
            DropTable("dbo.Papeis");
            CreateIndex("dbo.Matriculas", "MembrosID");
            AddForeignKey("dbo.Matriculas", "MembrosID", "dbo.Membros", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Usuarios", newName: "Membros");
        }
    }
}
