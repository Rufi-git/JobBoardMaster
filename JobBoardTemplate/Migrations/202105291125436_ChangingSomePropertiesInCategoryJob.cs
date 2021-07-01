namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingSomePropertiesInCategoryJob : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategoryBlogs", newName: "CategoryJobBlogs");
            RenameTable(name: "dbo.JobCategories", newName: "JobCategoryJobs");
            RenameColumn(table: "dbo.CategoryJobBlogs", name: "Category_Id", newName: "CategoryJob_Id");
            RenameColumn(table: "dbo.JobCategoryJobs", name: "Category_Id", newName: "CategoryJob_Id");
            RenameIndex(table: "dbo.CategoryJobBlogs", name: "IX_Category_Id", newName: "IX_CategoryJob_Id");
            RenameIndex(table: "dbo.JobCategoryJobs", name: "IX_Category_Id", newName: "IX_CategoryJob_Id");
            AddColumn("dbo.Categories", "JobCount", c => c.Int(nullable: false));
            DropColumn("dbo.Categories", "ArticleCount");
            DropColumn("dbo.Categories", "Vacancy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Vacancy", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "ArticleCount", c => c.Int(nullable: false));
            DropColumn("dbo.Categories", "JobCount");
            RenameIndex(table: "dbo.JobCategoryJobs", name: "IX_CategoryJob_Id", newName: "IX_Category_Id");
            RenameIndex(table: "dbo.CategoryJobBlogs", name: "IX_CategoryJob_Id", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.JobCategoryJobs", name: "CategoryJob_Id", newName: "Category_Id");
            RenameColumn(table: "dbo.CategoryJobBlogs", name: "CategoryJob_Id", newName: "Category_Id");
            RenameTable(name: "dbo.JobCategoryJobs", newName: "JobCategories");
            RenameTable(name: "dbo.CategoryJobBlogs", newName: "CategoryBlogs");
        }
    }
}
