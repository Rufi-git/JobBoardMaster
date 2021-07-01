namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChaningOccur : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "ImagePath", c => c.String(nullable: false));
        }
    }
}
