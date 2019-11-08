namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Conteudo_CamposBanner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conteudos", "Texto_Antes", c => c.String());
            AddColumn("dbo.Conteudos", "Texto_Depois", c => c.String());
            AddColumn("dbo.Conteudos", "Texto_Link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Conteudos", "Texto_Link");
            DropColumn("dbo.Conteudos", "Texto_Depois");
            DropColumn("dbo.Conteudos", "Texto_Antes");
        }
    }
}
