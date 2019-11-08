namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cidade_matriculas : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Matriculas", name: "Membro_Id", newName: "Usuario_Id");
            RenameIndex(table: "dbo.Matriculas", name: "IX_Membro_Id", newName: "IX_Usuario_Id");
            AddColumn("dbo.Matriculas", "Cidade", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matriculas", "Cidade");
            RenameIndex(table: "dbo.Matriculas", name: "IX_Usuario_Id", newName: "IX_Membro_Id");
            RenameColumn(table: "dbo.Matriculas", name: "Usuario_Id", newName: "Membro_Id");
        }
    }
}
