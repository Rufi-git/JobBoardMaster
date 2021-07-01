namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroppingSomeProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.Blogs", new[] { "AppUserId" });
            DropColumn("dbo.Authors", "UserName");
            DropColumn("dbo.Authors", "AuthorName");
            DropColumn("dbo.Authors", "AuthorSurname");
            DropColumn("dbo.Authors", "ImagePath");
            DropColumn("dbo.Blogs", "AppUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "AppUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Authors", "ImagePath", c => c.String());
            AddColumn("dbo.Authors", "AuthorSurname", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Authors", "AuthorName", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Authors", "UserName", c => c.String(nullable: false, maxLength: 40));
            CreateIndex("dbo.Blogs", "AppUserId");
            AddForeignKey("dbo.Blogs", "AppUserId", "dbo.AppUsers", "Id", cascadeDelete: true);
        }
    }
}
