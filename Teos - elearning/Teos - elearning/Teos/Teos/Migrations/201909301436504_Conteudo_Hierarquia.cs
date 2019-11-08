namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Conteudo_Hierarquia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conteudos", "Hierarquia", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Conteudos", "Hierarquia");
        }
    }
}
