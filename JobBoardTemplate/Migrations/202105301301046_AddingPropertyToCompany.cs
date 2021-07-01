namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPropertyToCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "Location");
        }
    }
}
