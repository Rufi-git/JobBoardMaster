namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPropertyToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "IsActive");
        }
    }
}
