namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TakingRisk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authors", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.Blogs", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.Blogs", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Authors", new[] { "AppUserId" });
            DropIndex("dbo.Blogs", new[] { "AuthorId" });
            DropIndex("dbo.Blogs", new[] { "AppUserId" });
            DropColumn("dbo.Blogs", "AuthorId");
            DropColumn("dbo.Blogs", "AppUserId");
            DropTable("dbo.Authors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        AppUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Blogs", "AppUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Blogs", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogs", "AppUserId");
            CreateIndex("dbo.Blogs", "AuthorId");
            CreateIndex("dbo.Authors", "AppUserId");
            AddForeignKey("dbo.Blogs", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Blogs", "AppUserId", "dbo.AppUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Authors", "AppUserId", "dbo.AppUsers", "Id", cascadeDelete: true);
        }
    }
}
