namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conteudo_remover_hierarquia : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Conteudos", "Hierarquia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Conteudos", "Hierarquia", c => c.Int(nullable: false));
        }
    }
}
