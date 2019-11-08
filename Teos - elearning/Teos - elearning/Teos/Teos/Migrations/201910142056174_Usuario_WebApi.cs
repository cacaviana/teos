namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuario_WebApi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", name: "ClientesId", c => c.Int(nullable: true));
            AddForeignKey("dbo.Usuarios", "ClientesId", "dbo.Clientes", "Id", cascadeDelete: true);

        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Usuarios", name: "ClientesId", newName: "Clientes_Id");
            RenameColumn(table: "dbo.Usuarios", name: "ClientesId", newName: "Clientes_Id");
        }
    }
}
