namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "UserName", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Authors", "AuthorName", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Authors", "AuthorSurname", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Authors", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "ImagePath");
            DropColumn("dbo.Authors", "AuthorSurname");
            DropColumn("dbo.Authors", "AuthorName");
            DropColumn("dbo.Authors", "UserName");
        }
    }
}
