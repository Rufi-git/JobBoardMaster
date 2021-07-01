namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDurationDecimalInJob : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "WorkDuration", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "WorkDuration", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
