namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cidade_matriculas_remover : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Matriculas", "Cidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matriculas", "Cidade", c => c.String());
        }
    }
}
