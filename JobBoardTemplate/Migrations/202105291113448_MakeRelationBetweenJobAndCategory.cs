namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeRelationBetweenJobAndCategory : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CompanyCandidates", newName: "CandidateCompanies");
            RenameTable(name: "dbo.JobCompanies", newName: "CompanyJobs");
            DropPrimaryKey("dbo.CandidateCompanies");
            DropPrimaryKey("dbo.CompanyJobs");
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        Job_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_Id, t.Category_Id })
                .ForeignKey("dbo.Jobs", t => t.Job_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Job_Id)
                .Index(t => t.Category_Id);
            
            AddPrimaryKey("dbo.CandidateCompanies", new[] { "Candidate_Id", "Company_Id" });
            AddPrimaryKey("dbo.CompanyJobs", new[] { "Company_Id", "Job_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.JobCategories", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.JobCategories", new[] { "Category_Id" });
            DropIndex("dbo.JobCategories", new[] { "Job_Id" });
            DropPrimaryKey("dbo.CompanyJobs");
            DropPrimaryKey("dbo.CandidateCompanies");
            DropTable("dbo.JobCategories");
            AddPrimaryKey("dbo.CompanyJobs", new[] { "Job_Id", "Company_Id" });
            AddPrimaryKey("dbo.CandidateCompanies", new[] { "Company_Id", "Candidate_Id" });
            RenameTable(name: "dbo.CompanyJobs", newName: "JobCompanies");
            RenameTable(name: "dbo.CandidateCompanies", newName: "CompanyCandidates");
        }
    }
}
