namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyToCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Vacancy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Vacancy");
        }
    }
}
