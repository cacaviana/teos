namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conteudo_add_hierarquia : DbMigration
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
