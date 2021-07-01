namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingIsPopularNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CategoryJobs", "IsPopular", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CategoryJobs", "IsPopular", c => c.Boolean(nullable: false));
        }
    }
}
