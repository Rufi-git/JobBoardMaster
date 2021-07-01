namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSomePropertiesToJob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Description", c => c.String(nullable: false, maxLength: 800));
            AddColumn("dbo.Jobs", "Responsibility", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Jobs", "Qualifications", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Jobs", "Benefits", c => c.String(nullable: false, maxLength: 600));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Benefits");
            DropColumn("dbo.Jobs", "Qualifications");
            DropColumn("dbo.Jobs", "Responsibility");
            DropColumn("dbo.Jobs", "Description");
        }
    }
}
