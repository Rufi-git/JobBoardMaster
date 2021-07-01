namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingImageNullableInAppUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppUsers", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppUsers", "ImagePath", c => c.String(nullable: false));
        }
    }
}
