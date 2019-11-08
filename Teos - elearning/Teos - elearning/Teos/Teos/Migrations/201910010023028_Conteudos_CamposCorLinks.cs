namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Conteudos_CamposCorLinks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conteudos", "Link_banner", c => c.String());
            AddColumn("dbo.Conteudos", "Cor_texto_banner", c => c.String());
            AddColumn("dbo.Conteudos", "Cor_fundo_banner", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Conteudos", "Cor_fundo_banner");
            DropColumn("dbo.Conteudos", "Cor_texto_banner");
            DropColumn("dbo.Conteudos", "Link_banner");
        }
    }
}
