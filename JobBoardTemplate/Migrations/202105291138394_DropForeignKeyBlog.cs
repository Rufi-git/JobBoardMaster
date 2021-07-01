namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropForeignKeyBlog : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.JobCategoryJobs", newName: "CategoryJobJobs");
            RenameTable(name: "dbo.CompanyJobs", newName: "JobCompanies");
            RenameTable(name: "dbo.CandidateCompanies", newName: "CompanyCandidates");
            DropForeignKey("dbo.CategoryJobs", "Blog_Id", "dbo.Blogs");
            DropIndex("dbo.CategoryJobs", new[] { "Blog_Id" });
            DropPrimaryKey("dbo.CategoryJobJobs");
            DropPrimaryKey("dbo.JobCompanies");
            DropPrimaryKey("dbo.CompanyCandidates");
            AddPrimaryKey("dbo.CategoryJobJobs", new[] { "CategoryJob_Id", "Job_Id" });
            AddPrimaryKey("dbo.JobCompanies", new[] { "Job_Id", "Company_Id" });
            AddPrimaryKey("dbo.CompanyCandidates", new[] { "Company_Id", "Candidate_Id" });
            DropColumn("dbo.CategoryJobs", "Blog_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoryJobs", "Blog_Id", c => c.Int());
            DropPrimaryKey("dbo.CompanyCandidates");
            DropPrimaryKey("dbo.JobCompanies");
            DropPrimaryKey("dbo.CategoryJobJobs");
            AddPrimaryKey("dbo.CompanyCandidates", new[] { "Candidate_Id", "Company_Id" });
            AddPrimaryKey("dbo.JobCompanies", new[] { "Company_Id", "Job_Id" });
            AddPrimaryKey("dbo.CategoryJobJobs", new[] { "Job_Id", "CategoryJob_Id" });
            CreateIndex("dbo.CategoryJobs", "Blog_Id");
            AddForeignKey("dbo.CategoryJobs", "Blog_Id", "dbo.Blogs", "Id");
            RenameTable(name: "dbo.CompanyCandidates", newName: "CandidateCompanies");
            RenameTable(name: "dbo.JobCompanies", newName: "CompanyJobs");
            RenameTable(name: "dbo.CategoryJobJobs", newName: "JobCategoryJobs");
        }
    }
}
