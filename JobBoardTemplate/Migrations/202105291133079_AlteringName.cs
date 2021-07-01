namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteringName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "CategoryJob_Id", "dbo.CategoryJobs");
            DropIndex("dbo.Jobs", new[] { "CategoryJob_Id" });
            CreateTable(
                "dbo.JobCategoryJobs",
                c => new
                    {
                        Job_Id = c.Int(nullable: false),
                        CategoryJob_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_Id, t.CategoryJob_Id })
                .ForeignKey("dbo.Jobs", t => t.Job_Id, cascadeDelete: true)
                .ForeignKey("dbo.CategoryJobs", t => t.CategoryJob_Id, cascadeDelete: true)
                .Index(t => t.Job_Id)
                .Index(t => t.CategoryJob_Id);
            
            DropColumn("dbo.Jobs", "CategoryJob_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "CategoryJob_Id", c => c.Int());
            DropForeignKey("dbo.JobCategoryJobs", "CategoryJob_Id", "dbo.CategoryJobs");
            DropForeignKey("dbo.JobCategoryJobs", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.JobCategoryJobs", new[] { "CategoryJob_Id" });
            DropIndex("dbo.JobCategoryJobs", new[] { "Job_Id" });
            DropTable("dbo.JobCategoryJobs");
            CreateIndex("dbo.Jobs", "CategoryJob_Id");
            AddForeignKey("dbo.Jobs", "CategoryJob_Id", "dbo.CategoryJobs", "Id");
        }
    }
}
