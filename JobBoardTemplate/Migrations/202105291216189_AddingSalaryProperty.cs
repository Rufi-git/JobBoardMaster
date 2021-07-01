namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSalaryProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "SalaryFrom", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Jobs", "SalaryTo", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Jobs", "Salary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Jobs", "SalaryTo");
            DropColumn("dbo.Jobs", "SalaryFrom");
        }
    }
}
