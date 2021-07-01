namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CandidateInJob : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "Candidate_Id", "dbo.Candidates");
            DropIndex("dbo.Jobs", new[] { "Candidate_Id" });
            CreateTable(
                "dbo.JobCandidates",
                c => new
                    {
                        Job_Id = c.Int(nullable: false),
                        Candidate_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_Id, t.Candidate_Id })
                .ForeignKey("dbo.Jobs", t => t.Job_Id, cascadeDelete: true)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id, cascadeDelete: true)
                .Index(t => t.Job_Id)
                .Index(t => t.Candidate_Id);
            
            DropColumn("dbo.Jobs", "Candidate_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Candidate_Id", c => c.Int());
            DropForeignKey("dbo.JobCandidates", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.JobCandidates", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.JobCandidates", new[] { "Candidate_Id" });
            DropIndex("dbo.JobCandidates", new[] { "Job_Id" });
            DropTable("dbo.JobCandidates");
            CreateIndex("dbo.Jobs", "Candidate_Id");
            AddForeignKey("dbo.Jobs", "Candidate_Id", "dbo.Candidates", "Id");
        }
    }
}
