namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingSubMenuTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        IsActive = c.Boolean(nullable: false),
                        Order = c.Byte(),
                        ActionName = c.String(nullable: false),
                        ControllerName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Menus", "ActionName", c => c.String());
            AlterColumn("dbo.Menus", "ControllerName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "ControllerName", c => c.String(nullable: false));
            AlterColumn("dbo.Menus", "ActionName", c => c.String(nullable: false));
            DropTable("dbo.SubMenus");
        }
    }
}
