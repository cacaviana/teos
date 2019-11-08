namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Require_WebServicesApi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WebServicesApis", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.WebServicesApis", "ClientId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WebServicesApis", "ClientId", c => c.String());
            AlterColumn("dbo.WebServicesApis", "Nome", c => c.String());
        }
    }
}
