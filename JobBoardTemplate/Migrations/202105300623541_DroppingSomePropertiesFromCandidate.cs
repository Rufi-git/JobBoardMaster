namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroppingSomePropertiesFromCandidate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Candidates", "Name");
            DropColumn("dbo.Candidates", "Surname");
            DropColumn("dbo.Candidates", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidates", "ImagePath", c => c.String(nullable: false));
            AddColumn("dbo.Candidates", "Surname", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Candidates", "Name", c => c.String(nullable: false, maxLength: 40));
        }
    }
}
