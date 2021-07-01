namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "IsTop", c => c.Boolean(nullable: false));
            DropColumn("dbo.Companies", "Ranking");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Ranking", c => c.Int(nullable: false));
            DropColumn("dbo.Companies", "IsTop");
        }
    }
}
