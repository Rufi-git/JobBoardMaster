namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingTestimonial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUsers", "Review", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppUsers", "Review");
        }
    }
}
