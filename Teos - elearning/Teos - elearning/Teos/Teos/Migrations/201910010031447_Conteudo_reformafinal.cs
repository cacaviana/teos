namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Conteudo_reformafinal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conteudos", "TextoBanner", c => c.String());
            AddColumn("dbo.Conteudos", "LinkBanner", c => c.String());
            AddColumn("dbo.Conteudos", "CorTextoBanner", c => c.Boolean(nullable: false));
            AddColumn("dbo.Conteudos", "CorFundoBanner", c => c.String());
            DropColumn("dbo.Conteudos", "Texto_Antes");
            DropColumn("dbo.Conteudos", "Texto_Depois");
            DropColumn("dbo.Conteudos", "Texto_Link");
            DropColumn("dbo.Conteudos", "Link_banner");
            DropColumn("dbo.Conteudos", "Cor_texto_banner");
            DropColumn("dbo.Conteudos", "Cor_fundo_banner");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Conteudos", "Cor_fundo_banner", c => c.String());
            AddColumn("dbo.Conteudos", "Cor_texto_banner", c => c.String());
            AddColumn("dbo.Conteudos", "Link_banner", c => c.String());
            AddColumn("dbo.Conteudos", "Texto_Link", c => c.String());
            AddColumn("dbo.Conteudos", "Texto_Depois", c => c.String());
            AddColumn("dbo.Conteudos", "Texto_Antes", c => c.String());
            DropColumn("dbo.Conteudos", "CorFundoBanner");
            DropColumn("dbo.Conteudos", "CorTextoBanner");
            DropColumn("dbo.Conteudos", "LinkBanner");
            DropColumn("dbo.Conteudos", "TextoBanner");
        }
    }
}
