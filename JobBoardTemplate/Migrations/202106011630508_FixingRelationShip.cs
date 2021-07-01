namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingRelationShip : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "CategoryBlog_Id", "dbo.CategoryBlogs");
            DropIndex("dbo.Blogs", new[] { "CategoryBlog_Id" });
            CreateTable(
                "dbo.CategoryBlogBlogs",
                c => new
                    {
                        CategoryBlog_Id = c.Int(nullable: false),
                        Blog_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryBlog_Id, t.Blog_Id })
                .ForeignKey("dbo.CategoryBlogs", t => t.CategoryBlog_Id, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.Blog_Id, cascadeDelete: true)
                .Index(t => t.CategoryBlog_Id)
                .Index(t => t.Blog_Id);
            
            DropColumn("dbo.Blogs", "CategoryBlog_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "CategoryBlog_Id", c => c.Int());
            DropForeignKey("dbo.CategoryBlogBlogs", "Blog_Id", "dbo.Blogs");
            DropForeignKey("dbo.CategoryBlogBlogs", "CategoryBlog_Id", "dbo.CategoryBlogs");
            DropIndex("dbo.CategoryBlogBlogs", new[] { "Blog_Id" });
            DropIndex("dbo.CategoryBlogBlogs", new[] { "CategoryBlog_Id" });
            DropTable("dbo.CategoryBlogBlogs");
            CreateIndex("dbo.Blogs", "CategoryBlog_Id");
            AddForeignKey("dbo.Blogs", "CategoryBlog_Id", "dbo.CategoryBlogs", "Id");
        }
    }
}
