namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retirar_dataannotation_usuarios : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Login", c => c.String());
            AlterColumn("dbo.Usuarios", "Senha", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Senha", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Login", c => c.String(nullable: false));
        }
    }
}
