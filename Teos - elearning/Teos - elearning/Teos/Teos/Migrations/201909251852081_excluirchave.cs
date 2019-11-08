namespace Teos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class excluirchave : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Convites", "TurmasId");
            AddForeignKey("dbo.Convites", "TurmasId", "dbo.Turmas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Convites", "TurmasId", "dbo.Turmas");
            DropIndex("dbo.Convites", new[] { "TurmasId" });
        }
    }
}
