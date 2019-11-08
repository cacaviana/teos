namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarMembrosparaUsuarioeCriarentidadePapeisparte2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "PapeisId", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuarios", "PapeisId");
            AddForeignKey("dbo.Usuarios", "PapeisId", "dbo.Papeis", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "PapeisId", "dbo.Papeis");
            DropIndex("dbo.Usuarios", new[] { "PapeisId" });
            DropColumn("dbo.Usuarios", "PapeisId");
        }
    }
}
