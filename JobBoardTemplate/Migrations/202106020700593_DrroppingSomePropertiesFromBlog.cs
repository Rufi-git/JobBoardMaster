namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrroppingSomePropertiesFromBlog : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.Blogs", new[] { "AppUserId" });
            DropColumn("dbo.Blogs", "AppUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "AppUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogs", "AppUserId");
            AddForeignKey("dbo.Blogs", "AppUserId", "dbo.AppUsers", "Id", cascadeDelete: true);
        }
    }
}
