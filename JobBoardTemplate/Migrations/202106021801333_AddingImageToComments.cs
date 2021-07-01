namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingImageToComments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ImagePath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "ImagePath");
        }
    }
}
