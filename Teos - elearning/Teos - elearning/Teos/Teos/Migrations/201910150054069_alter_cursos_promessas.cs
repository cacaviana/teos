namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_cursos_promessas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cursos", "Promessa", c => c.String());
            DropColumn("dbo.Cursos", "Link_Imagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cursos", "Link_Imagem", c => c.String());
            DropColumn("dbo.Cursos", "Promessa");
        }
    }
}
