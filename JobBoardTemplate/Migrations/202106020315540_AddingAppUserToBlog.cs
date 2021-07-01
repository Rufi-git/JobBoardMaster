namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAppUserToBlog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "AppUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogs", "AppUserId");
            AddForeignKey("dbo.Blogs", "AppUserId", "dbo.AppUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.Blogs", new[] { "AppUserId" });
            DropColumn("dbo.Blogs", "AppUserId");
        }
    }
}
