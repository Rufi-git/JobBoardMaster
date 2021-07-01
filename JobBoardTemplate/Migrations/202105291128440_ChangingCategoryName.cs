namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingCategoryName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "CategoryJobs");
            DropForeignKey("dbo.CategoryJobBlogs", "CategoryJob_Id", "dbo.Categories");
            DropForeignKey("dbo.CategoryJobBlogs", "Blog_Id", "dbo.Blogs");
            DropForeignKey("dbo.JobCategoryJobs", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.JobCategoryJobs", "CategoryJob_Id", "dbo.Categories");
            DropIndex("dbo.CategoryJobBlogs", new[] { "CategoryJob_Id" });
            DropIndex("dbo.CategoryJobBlogs", new[] { "Blog_Id" });
            DropIndex("dbo.JobCategoryJobs", new[] { "Job_Id" });
            DropIndex("dbo.JobCategoryJobs", new[] { "CategoryJob_Id" });
            AddColumn("dbo.CategoryJobs", "Blog_Id", c => c.Int());
            AddColumn("dbo.Jobs", "CategoryJob_Id", c => c.Int());
            CreateIndex("dbo.CategoryJobs", "Blog_Id");
            CreateIndex("dbo.Jobs", "CategoryJob_Id");
            AddForeignKey("dbo.Jobs", "CategoryJob_Id", "dbo.CategoryJobs", "Id");
            AddForeignKey("dbo.CategoryJobs", "Blog_Id", "dbo.Blogs", "Id");
            DropTable("dbo.CategoryJobBlogs");
            DropTable("dbo.JobCategoryJobs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobCategoryJobs",
                c => new
                    {
                        Job_Id = c.Int(nullable: false),
                        CategoryJob_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_Id, t.CategoryJob_Id });
            
            CreateTable(
                "dbo.CategoryJobBlogs",
                c => new
                    {
                        CategoryJob_Id = c.Int(nullable: false),
                        Blog_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryJob_Id, t.Blog_Id });
            
            DropForeignKey("dbo.CategoryJobs", "Blog_Id", "dbo.Blogs");
            DropForeignKey("dbo.Jobs", "CategoryJob_Id", "dbo.CategoryJobs");
            DropIndex("dbo.Jobs", new[] { "CategoryJob_Id" });
            DropIndex("dbo.CategoryJobs", new[] { "Blog_Id" });
            DropColumn("dbo.Jobs", "CategoryJob_Id");
            DropColumn("dbo.CategoryJobs", "Blog_Id");
            CreateIndex("dbo.JobCategoryJobs", "CategoryJob_Id");
            CreateIndex("dbo.JobCategoryJobs", "Job_Id");
            CreateIndex("dbo.CategoryJobBlogs", "Blog_Id");
            CreateIndex("dbo.CategoryJobBlogs", "CategoryJob_Id");
            AddForeignKey("dbo.JobCategoryJobs", "CategoryJob_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobCategoryJobs", "Job_Id", "dbo.Jobs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CategoryJobBlogs", "Blog_Id", "dbo.Blogs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CategoryJobBlogs", "CategoryJob_Id", "dbo.Categories", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.CategoryJobs", newName: "Categories");
        }
    }
}
