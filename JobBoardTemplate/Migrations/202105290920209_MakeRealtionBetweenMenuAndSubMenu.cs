namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeRealtionBetweenMenuAndSubMenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubMenus", "MenuId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubMenus", "MenuId");
            AddForeignKey("dbo.SubMenus", "MenuId", "dbo.Menus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubMenus", "MenuId", "dbo.Menus");
            DropIndex("dbo.SubMenus", new[] { "MenuId" });
            DropColumn("dbo.SubMenus", "MenuId");
        }
    }
}
