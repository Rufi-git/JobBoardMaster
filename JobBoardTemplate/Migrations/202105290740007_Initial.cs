namespace JobBoardTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 40),
                        Surname = c.String(nullable: false, maxLength: 40),
                        Age = c.Byte(nullable: false),
                        Gender = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 40),
                        ImagePath = c.String(nullable: false),
                        AboutMe = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 40),
                        AuthorName = c.String(nullable: false, maxLength: 40),
                        AuthorSurname = c.String(nullable: false, maxLength: 40),
                        Description = c.String(nullable: false),
                        ImagePath = c.String(),
                        AppUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .Index(t => t.AppUserId);
            
            CreateTable(
                "dbo.Blogs",
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
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        isActive = c.Boolean(nullable: false),
                        ArticleCount = c.Int(nullable: false),
                        IsPopular = c.Boolean(nullable: false),
                        Order = c.Byte(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Text = c.String(nullable: false, maxLength: 500),
                        PublishDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        Email = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        BlogId = c.Int(nullable: false),
                        AppUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: false)
                .Index(t => t.BlogId)
                .Index(t => t.AppUserId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        isActive = c.Boolean(nullable: false),
                        Order = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Surname = c.String(nullable: false, maxLength: 40),
                        Occupation = c.String(nullable: false, maxLength: 40),
                        ImagePath = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Order = c.Int(),
                        AppUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .Index(t => t.AppUserId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        ImagePath = c.String(nullable: false),
                        Ranking = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Order = c.Int(),
                        FounderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Founders", t => t.FounderId, cascadeDelete: true)
                .Index(t => t.FounderId);
            
            CreateTable(
                "dbo.Founders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Surname = c.String(nullable: false, maxLength: 40),
                        Email = c.String(nullable: false),
                        Occupation = c.String(nullable: false, maxLength: 50),
                        ImagePath = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        ImagePath = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        WorkDuration = c.String(nullable: false, maxLength: 30),
                        PublisDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Order = c.Int(),
                        Vacancy = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Candidate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id)
                .Index(t => t.Candidate_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Order = c.Byte(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
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
            
            CreateTable(
                "dbo.CategoryBlogs",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Blog_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Blog_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.Blog_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Blog_Id);
            
            CreateTable(
                "dbo.TagBlogs",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Blog_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Blog_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.Blog_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Blog_Id);
            
            CreateTable(
                "dbo.CompanyCandidates",
                c => new
                    {
                        Company_Id = c.Int(nullable: false),
                        Candidate_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Company_Id, t.Candidate_Id })
                .ForeignKey("dbo.Companies", t => t.Company_Id, cascadeDelete: true)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id, cascadeDelete: true)
                .Index(t => t.Company_Id)
                .Index(t => t.Candidate_Id);
            
            CreateTable(
                "dbo.JobCompanies",
                c => new
                    {
                        Job_Id = c.Int(nullable: false),
                        Company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_Id, t.Company_Id })
                .ForeignKey("dbo.Jobs", t => t.Job_Id, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Company_Id, cascadeDelete: true)
                .Index(t => t.Job_Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.JobCompanies", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.JobCompanies", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.Companies", "FounderId", "dbo.Founders");
            DropForeignKey("dbo.CompanyCandidates", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.CompanyCandidates", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Candidates", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.TagBlogs", "Blog_Id", "dbo.Blogs");
            DropForeignKey("dbo.TagBlogs", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Comments", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.CategoryBlogs", "Blog_Id", "dbo.Blogs");
            DropForeignKey("dbo.CategoryBlogs", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Authors", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.JobCompanies", new[] { "Company_Id" });
            DropIndex("dbo.JobCompanies", new[] { "Job_Id" });
            DropIndex("dbo.CompanyCandidates", new[] { "Candidate_Id" });
            DropIndex("dbo.CompanyCandidates", new[] { "Company_Id" });
            DropIndex("dbo.TagBlogs", new[] { "Blog_Id" });
            DropIndex("dbo.TagBlogs", new[] { "Tag_Id" });
            DropIndex("dbo.CategoryBlogs", new[] { "Blog_Id" });
            DropIndex("dbo.CategoryBlogs", new[] { "Category_Id" });
            DropIndex("dbo.Jobs", new[] { "Candidate_Id" });
            DropIndex("dbo.Companies", new[] { "FounderId" });
            DropIndex("dbo.Candidates", new[] { "AppUserId" });
            DropIndex("dbo.Comments", new[] { "AppUserId" });
            DropIndex("dbo.Comments", new[] { "BlogId" });
            DropIndex("dbo.Blogs", new[] { "AuthorId" });
            DropIndex("dbo.Authors", new[] { "AppUserId" });
            DropTable("dbo.JobCompanies");
            DropTable("dbo.CompanyCandidates");
            DropTable("dbo.TagBlogs");
            DropTable("dbo.CategoryBlogs");
            DropTable("dbo.Menus");
            DropTable("dbo.Contacts");
            DropTable("dbo.Jobs");
            DropTable("dbo.Founders");
            DropTable("dbo.Companies");
            DropTable("dbo.Candidates");
            DropTable("dbo.Tags");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
            DropTable("dbo.Authors");
            DropTable("dbo.AppUsers");
        }
    }
}
