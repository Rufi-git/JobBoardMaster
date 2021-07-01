namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingTestimonialModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppUsers", "Review", c => c.String(maxLength: 600));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppUsers", "Review", c => c.String());
        }
    }
}
