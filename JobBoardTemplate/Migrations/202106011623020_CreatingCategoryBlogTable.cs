namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingCategoryBlogTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryBlogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        isActive = c.Boolean(nullable: false),
                        IsPopular = c.Boolean(nullable: false),
                        Order = c.Byte(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Blogs", "CategoryBlog_Id", c => c.Int());
            CreateIndex("dbo.Blogs", "CategoryBlog_Id");
            AddForeignKey("dbo.Blogs", "CategoryBlog_Id", "dbo.CategoryBlogs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "CategoryBlog_Id", "dbo.CategoryBlogs");
            DropIndex("dbo.Blogs", new[] { "CategoryBlog_Id" });
            DropColumn("dbo.Blogs", "CategoryBlog_Id");
            DropTable("dbo.CategoryBlogs");
        }
    }
}
