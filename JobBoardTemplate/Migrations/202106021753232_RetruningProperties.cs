namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetruningProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "AppUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "AppUserId");
            AddForeignKey("dbo.Comments", "AppUserId", "dbo.AppUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.Comments", new[] { "AppUserId" });
            DropColumn("dbo.Comments", "AppUserId");
        }
    }
}
