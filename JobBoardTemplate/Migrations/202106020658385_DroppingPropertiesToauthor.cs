namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroppingPropertiesToauthor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Authors", "UserName");
            DropColumn("dbo.Authors", "AuthorName");
            DropColumn("dbo.Authors", "AuthorSurname");
            DropColumn("dbo.Authors", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "ImagePath", c => c.String());
            AddColumn("dbo.Authors", "AuthorSurname", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Authors", "AuthorName", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Authors", "UserName", c => c.String(nullable: false, maxLength: 40));
        }
    }
}
