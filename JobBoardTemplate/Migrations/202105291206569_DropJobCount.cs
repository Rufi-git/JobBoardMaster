namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropJobCount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CategoryJobs", "JobCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoryJobs", "JobCount", c => c.Int(nullable: false));
        }
    }
}
