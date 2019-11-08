namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Renomear_WebServicesAPi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WebServicesApis", "ClientSecret", c => c.String());
            DropColumn("dbo.WebServicesApis", "ClienteSercret");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WebServicesApis", "ClienteSercret", c => c.String());
            DropColumn("dbo.WebServicesApis", "ClientSecret");
        }
    }
}
