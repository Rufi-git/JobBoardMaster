namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesThatIdidntSupposedToHapen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        ShortDescription = c.String(nullable: false, maxLength: 300),
                        Description = c.String(nullable: false, maxLength: 1000),
                        ImagePath = c.String(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        WrittenDate = c.DateTime(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        Order = c.Int(),
                        isPopular = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ArticleModels");
        }
    }
}
