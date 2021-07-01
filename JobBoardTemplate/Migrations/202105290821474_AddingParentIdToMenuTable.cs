namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingParentIdToMenuTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "ParentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "ParentId");
        }
    }
}
