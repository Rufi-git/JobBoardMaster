namespace JobBoardTemplate.Migrations
{
    using JobBoardTemplate.Data;
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JobBoardTemplate.Data.JobDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JobBoardTemplate.Data.JobDbContext context)
        {
            #region AppUserList
            //string email = ConfigurationManager.AppSettings["Email"];
            //string name = ConfigurationManager.AppSettings["Name"];
            //string surname = ConfigurationManager.AppSettings["Surname"];
            //string userNamme = ConfigurationManager.AppSettings["UserName"];
            //string password = ConfigurationManager.AppSettings["Password"];
            //byte age = Convert.ToByte(ConfigurationManager.AppSettings["Age"]);
            //string gender = ConfigurationManager.AppSettings["Gender"];
            //context.AppUsers.AddOrUpdate(new AppUser
            //{
            //    Id = 1,
            //    Name = name,
            //    Surname = surname,
            //    Email = email,
            //    UserName = userNamme,
            //    Password = password,
            //    AboutMe = "There are many variations of passages of Lorem Ipsum available, but the majority have " +
            //    "suffered alteration in some form, by injected humour, or" +
            //    " randomised words which don't look even slightly embarrassing.",
            //    Age = age,
            //    Gender = gender,
            //    ImagePath = "2.jpg",
            //    Review = "Working in conjunction with humanitarian aid agencies," +
            //    "we have supported programmes to help alleviate human suffering through animal welfare when people might depend on livestock as their only source of income or food."
            //});
            #endregion

            #region MenuList
            //context.Menus.AddOrUpdate(new Menu
            //{
            //    Id = 1,
            //    Name = "Browse Job",
            //    ActionName = "Jobs",
            //    ControllerName = "Home",
            //    IsActive = true,
            //    Order = 1,
            //},
            //new Menu
            //{
            //    Id = 2,
            //    Name = "Pages",
            //    ActionName = null,
            //    ControllerName = null,
            //    IsActive = true,
            //    Order = 2,
            //},
            //new Menu
            //{
            //    Id = 3,
            //    Name = "Blog",
            //    ActionName = null,
            //    ControllerName = null,
            //    IsActive = true,
            //    Order = 3,
            //},
            //new Menu
            //{
            //    Id = 4,
            //    Name = "Contact",
            //    ActionName = "Contact",
            //    ControllerName = "Home",
            //    IsActive = true,
            //    Order = 4,
            //});
            #endregion

            #region SubMenuList
            //context.SubMenus.AddOrUpdate(new SubMenu
            //{
            //    Id = 1,
            //    Name = "Candidates",
            //    ActionName = "Candidate",
            //    ControllerName = "Home",
            //    IsActive = true,
            //    MenuId = 2,
            //    Order = 1,
            //},
            //new SubMenu
            //{
            //    Id = 2,
            //    Name = "Job Details",
            //    ActionName = "JobDetails",
            //    ControllerName = "Home",
            //    IsActive = true,
            //    MenuId = 2,
            //    Order = 2,
            //},
            //new SubMenu
            //{
            //    Id = 3,
            //    Name = "Elements",
            //    ActionName = "Elements",
            //    ControllerName = "Home",
            //    IsActive = true,
            //    MenuId = 2,
            //    Order = 3,
            //},
            //new SubMenu
            //{
            //    Id = 4,
            //    Name = "Blog",
            //    ActionName = "Blog",
            //    ControllerName = "Home",
            //    IsActive = true,
            //    MenuId = 3,
            //    Order = 4,
            //},
            //new SubMenu
            //{
            //    Id = 5,
            //    Name = "Single-Blog",
            //    ActionName = "SingleBlog",
            //    ControllerName = "Home",
            //    IsActive = true,
            //    MenuId = 3,
            //    Order = 5,
            //});
            #endregion

            #region CategoryJobList
            //context.CategoryJobs.AddOrUpdate(new CategoryJob
            //{
            //    Id = 1,
            //    Name = "Design & Creative",
            //    IsActive = true,
            //    IsPopular = true,
            //    Order = 1
            //},
            //new CategoryJob
            //{
            //    Id = 2,
            //    Name = "Marketing",
            //    IsActive = true,
            //    IsPopular = true,
            //    Order = 2,
            //},
            //new CategoryJob
            //{
            //    Id = 3,
            //    Name = "Telemarketing",
            //    IsActive = true,
            //    IsPopular = true,
            //    Order = 3
            //},
            //new CategoryJob
            //{
            //    Id = 4,
            //    Name = "Administration",
            //    IsActive = true,
            //    IsPopular = true,
            //    Order = 4
            //},
            //new CategoryJob
            //{
            //    Id = 5,
            //    Name = "Teaching & Education",
            //    IsActive = true,
            //    IsPopular = true,
            //    Order = 5
            //},
            //    new CategoryJob
            //    {
            //        Id = 6,
            //        Name = "Engineering",
            //        IsActive = true,
            //        IsPopular = true,
            //        Order = 6,
            //    },
            //    new CategoryJob
            //    {
            //        Id = 7,
            //        Name = "Garments / Textile",
            //        IsActive = true,
            //        IsPopular = true,
            //        Order = 7
            //    });
            #endregion

            #region JobList
            //context.Jobs.AddOrUpdate(new Job
            //{
            //    Id = 1,
            //    SalaryFrom = 50,
            //    SalaryTo = 120,
            //    IsActive = true,
            //    Order = 1,
            //    ImagePath = "1.svg",
            //    Location = "California, USA",
            //    Name = "Software Engineer",
            //    Vacancy = 2,
            //    ExpireDate = DateTime.Now.AddMonths(6),
            //    PublisDate = DateTime.Now,
            //    WorkDuration = 6,
            //    Description = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour" +
            //    ", or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything" +
            //    " embarrassing.Variations of passages of lorem Ipsum available,but the majority have suffered alteration in some form, by injected humour, or randomised words" +
            //    " which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing.",
            //    Responsibility = "The applicants should have experience in the following areas." +
            //    "Have sound knowledge of commercial activities. Leadership,analytical, and problem - solving abilities." +
            //    "Should have vast knowledge in IAS / IFRS, Company Act, Income Tax, VAT.",
            //    Qualifications = "The applicants should have experience in the following areas." +
            //    "Have sound knowledge of commercial activities. Leadership,analytical, and problem - solving abilities." +
            //    "Should have vast knowledge in IAS / IFRS, Company Act, Income Tax, VAT.",
            //    Benefits = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered" +
            //    " alteration in some form, by injected humour, or randomised words which don't look even slightly " +
            //    "believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing."
            //},
            //new Job
            //{
            //    Id = 2,
            //    SalaryFrom = 50,
            //    SalaryTo = 120,
            //    IsActive = true,
            //    Order = 2,
            //    ImagePath = "2.svg",
            //    Location = "California, USA",
            //    Name = "Digital Marketer",
            //    Vacancy = 2,
            //    ExpireDate = DateTime.Now.AddMonths(6),
            //    PublisDate = DateTime.Now,
            //    WorkDuration = 6,
            //    Description = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour" +
            //    ", or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything" +
            //    " embarrassing.Variations of passages of lorem Ipsum available,but the majority have suffered alteration in some form, by injected humour, or randomised words" +
            //    " which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing.",
            //    Responsibility = "The applicants should have experience in the following areas." +
            //    "Have sound knowledge of commercial activities. Leadership,analytical, and problem - solving abilities." +
            //    "Should have vast knowledge in IAS / IFRS, Company Act, Income Tax, VAT.",
            //    Qualifications = "The applicants should have experience in the following areas." +
            //    "Have sound knowledge of commercial activities. Leadership,analytical, and problem - solving abilities." +
            //    "Should have vast knowledge in IAS / IFRS, Company Act, Income Tax, VAT.",
            //    Benefits = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered" +
            //    " alteration in some form, by injected humour, or randomised words which don't look even slightly " +
            //    "believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing."
            //},
            //new Job
            //{
            //    Id = 3,
            //    SalaryFrom = 50,
            //    SalaryTo = 120,
            //    IsActive = true,
            //    Order = 3,
            //    ImagePath = "3.svg",
            //    Location = "California, USA",
            //    Name = "Wordpress Developer",
            //    Vacancy = 2,
            //    ExpireDate = DateTime.Now.AddMonths(6),
            //    PublisDate = DateTime.Now,
            //    WorkDuration = 6,
            //    Description = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour" +
            //    ", or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything" +
            //    " embarrassing.Variations of passages of lorem Ipsum available,but the majority have suffered alteration in some form, by injected humour, or randomised words" +
            //    " which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing.",
            //    Responsibility = "The applicants should have experience in the following areas." +
            //    "Have sound knowledge of commercial activities. Leadership,analytical, and problem - solving abilities." +
            //    "Should have vast knowledge in IAS / IFRS, Company Act, Income Tax, VAT.",
            //    Qualifications = "The applicants should have experience in the following areas." +
            //    "Have sound knowledge of commercial activities. Leadership,analytical, and problem - solving abilities." +
            //    "Should have vast knowledge in IAS / IFRS, Company Act, Income Tax, VAT.",
            //    Benefits = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered" +
            //    " alteration in some form, by injected humour, or randomised words which don't look even slightly " +
            //    "believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing."
            //},
            //new Job
            //{
            //    Id = 4,
            //    SalaryFrom = 50,
            //    SalaryTo = 120,
            //    IsActive = true,
            //    Order = 4,
            //    ImagePath = "4.svg",
            //    Location = "California, USA",
            //    Name = "Visual Designer",
            //    Vacancy = 2,
            //    ExpireDate = DateTime.Now.AddMonths(6),
            //    PublisDate = DateTime.Now,
            //    WorkDuration = 6,
            //    Description = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour" +
            //    ", or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything" +
            //    " embarrassing.Variations of passages of lorem Ipsum available,but the majority have suffered alteration in some form, by injected humour, or randomised words" +
            //    " which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing.",
            //    Responsibility = "The applicants should have experience in the following areas." +
            //    "Have sound knowledge of commercial activities. Leadership,analytical, and problem - solving abilities." +
            //    "Should have vast knowledge in IAS / IFRS, Company Act, Income Tax, VAT.",
            //    Qualifications = "The applicants should have experience in the following areas." +
            //    "Have sound knowledge of commercial activities. Leadership,analytical, and problem - solving abilities." +
            //    "Should have vast knowledge in IAS / IFRS, Company Act, Income Tax, VAT.",
            //    Benefits = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered" +
            //    " alteration in some form, by injected humour, or randomised words which don't look even slightly " +
            //    "believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing."
            //},
            //new Job
            //{
            //    Id = 5,
            //    SalaryFrom = 50,
            //    SalaryTo = 120,
            //    IsActive = true,
            //    Order = 5,
            //    ImagePath = "5.svg",
            //    Location = "California, USA",
            //    Name = "Software Engineer",
            //    Vacancy = 2,
            //    ExpireDate = DateTime.Now.AddMonths(6),
            //    PublisDate = DateTime.Now,
            //    WorkDuration = 6,
            //    Description = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour" +
            //    ", or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything" +
            //    " embarrassing.Variations of passages of lorem Ipsum available,but the majority have suffered alteration in some form, by injected humour, or randomised words" +
            //    " which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing.",
            //    Responsibility = "The applicants should have experience in the following areas." +
            //    "Have sound knowledge of commercial activities. Leadership,analytical, and problem - solving abilities." +
            //    "Should have vast knowledge in IAS / IFRS, Company Act, Income Tax, VAT.",
            //    Qualifications = "The applicants should have experience in the following areas." +
            //    "Have sound knowledge of commercial activities. Leadership,analytical, and problem - solving abilities." +
            //    "Should have vast knowledge in IAS / IFRS, Company Act, Income Tax, VAT.",
            //    Benefits = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered" +
            //    " alteration in some form, by injected humour, or randomised words which don't look even slightly " +
            //    "believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing."
            //},
            //new Job
            //{
            //    Id = 6,
            //    SalaryFrom = 50,
            //    SalaryTo = 120,
            //    IsActive = true,
            //    Order = 6,
            //    ImagePath = "1.svg",
            //    Location = "California, USA",
            //    Name = "Creative Designer",
            //    Vacancy = 2,
            //    ExpireDate = DateTime.Now.AddMonths(6),
            //    PublisDate = DateTime.Now,
            //    WorkDuration = 6,
            //    Description = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour" +
            //    ", or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything" +
            //    " embarrassing.Variations of passages of lorem Ipsum available,but the majority have suffered alteration in some form, by injected humour, or randomised words" +
            //    " which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing.",
            //    Responsibility = "The applicants should have experience in the following areas." +
            //    "Have sound knowledge of commercial activities. Leadership,analytical, and problem - solving abilities." +
            //    "Should have vast knowledge in IAS / IFRS, Company Act, Income Tax, VAT.",
            //    Qualifications = "The applicants should have experience in the following areas." +
            //    "Have sound knowledge of commercial activities. Leadership,analytical, and problem - solving abilities." +
            //    "Should have vast knowledge in IAS / IFRS, Company Act, Income Tax, VAT.",
            //    Benefits = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered" +
            //    " alteration in some form, by injected humour, or randomised words which don't look even slightly " +
            //    "believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing."
            //});
            #endregion

            #region FounderList
            //context.Founders.AddOrUpdate(new Founder
            //{
            //    Id = 1,
            //    Surname = "Feridov",
            //    Name = "Kamal",
            //    Email = "kamal@gmail.com",
            //    IsActive = true,
            //    Occupation = "Software Development",
            //    ImagePath = "1.jpg",
            //},
            //new Founder
            //{
            //    Id = 2,
            //    Surname = "Sabir",
            //    Name = "Huseynov",
            //    Email = "sabir@gmail.com",
            //    IsActive = true,
            //    Occupation = "Komputer Science",
            //    ImagePath = "2.jpg",
            //});
            #endregion

            #region CompanyList
            //context.Companies.AddOrUpdate(new Company
            //{
            //    Id = 1,
            //    Name = "Snack Studio",
            //    IsActive = true,
            //    Order = 1,
            //    ImagePath = "5.svg",
            //    FounderId = 1,
            //    IsTop = true,
            //    Location = "California, USA"
            //},
            //new Company
            //{
            //    Id = 2,
            //    Name = "Snack Studio",
            //    IsActive = true,
            //    Order = 2,
            //    ImagePath = "4.svg",
            //    FounderId = 2,
            //    IsTop = true,
            //    Location = "California, USA"
            //},
            //new Company
            //{
            //    Id = 3,
            //    Name = "Snack Studio",
            //    IsActive = true,
            //    Order = 3,
            //    ImagePath = "3.svg",
            //    FounderId = 2,
            //    IsTop = true,
            //    Location = "California, USA"
            //},
            //new Company
            //{
            //    Id = 4,
            //    Name = "Snack Studio",
            //    IsActive = true,
            //    Order = 4,
            //    ImagePath = "1.svg",
            //    FounderId = 1,
            //    IsTop = true,
            //    Location = "California, USA"
            //});
            #endregion

            #region CandidateList
            //context.Candidates.AddOrUpdate(new Candidate
            //{
            //    Id = 1,
            //    AppUserId = 34,
            //    IsActive = true,
            //    Occupation = "Software Engineer",
            //    Order = 1,
            //},
            //new Candidate
            //{
            //    Id = 2,
            //    AppUserId = 35,
            //    IsActive = true,
            //    Occupation = "Software Engineer",
            //    Order = 2
            //},
            //new Candidate
            //{
            //    Id = 3,
            //    AppUserId = 34,
            //    IsActive = true,
            //    Occupation = "Software Engineer",
            //    Order = 3
            //});
            #endregion

            #region BlogList
            //context.Blogs.AddOrUpdate(new Blog
            //{
            //    Id = 1,
            //    ShortDescription = "That dominion stars lights dominion divide years for fourth have don't stars is that he earth it first without heaven in place seed it second morning saying.",
            //    ImagePath = "single_blog_1.png",
            //    Title = "Google inks pact for new 35-storey office",
            //    isActive = true,
            //    isPopular = false,
            //    Order = 1,
            //    PublishDate = DateTime.Now.AddHours(2),
            //    Description = "MCSE boot camps have its supporters and its detractors. Some people do not understand why you should have to spend money on boot camp when you can get the MCSE study materials yourself at a fraction of the camp price. However, who has the willpower to actually sit through a self-imposed MCSE training. who has the willpower to actually",
            //    WrittenDate = DateTime.Now,
            //},
            //new Blog
            //{
            //    Id = 2,
            //    ShortDescription = "That dominion stars lights dominion divide years for fourth have don't stars is that he earth it first without heaven in place seed it second morning saying.",
            //    ImagePath = "single_blog_2.png",
            //    Title = "Google inks pact for new 35-storey office",
            //    isActive = true,
            //    isPopular = true,
            //    Order = 2,
            //    PublishDate = DateTime.Now.AddHours(2),
            //    Description = "MCSE boot camps have its supporters and its detractors. Some people do not understand why you should have to spend money on boot camp when you can get the MCSE study materials yourself at a fraction of the camp price. However, who has the willpower to actually sit through a self-imposed MCSE training. who has the willpower to actually",
            //    WrittenDate = DateTime.Now,
            //},
            //new Blog
            //{
            //    Id = 3,
            //    ShortDescription = "That dominion stars lights dominion divide years for fourth have don't stars is that he earth it first without heaven in place seed it second morning saying.",
            //    ImagePath = "single_blog_3.png",
            //    Title = "Google inks pact for new 35-storey office",
            //    isActive = true,
            //    isPopular = false,
            //    Order = 3,
            //    PublishDate = DateTime.Now.AddHours(2),
            //    Description = "MCSE boot camps have its supporters and its detractors. Some people do not understand why you should have to spend money on boot camp when you can get the MCSE study materials yourself at a fraction of the camp price. However, who has the willpower to actually sit through a self-imposed MCSE training. who has the willpower to actually",
            //    WrittenDate = DateTime.Now,
            //},
            //new Blog
            //{
            //    Id = 4,
            //    ShortDescription = "That dominion stars lights dominion divide years for fourth have don't stars is that he earth it first without heaven in place seed it second morning saying.",
            //    ImagePath = "single_blog_4.png",
            //    Title = "Google inks pact for new 35-storey office",
            //    isActive = true,
            //    isPopular = true,
            //    Order = 4,
            //    PublishDate = DateTime.Now.AddHours(2),
            //    Description = "MCSE boot camps have its supporters and its detractors. Some people do not understand why you should have to spend money on boot camp when you can get the MCSE study materials yourself at a fraction of the camp price. However, who has the willpower to actually sit through a self-imposed MCSE training. who has the willpower to actually",
            //    WrittenDate = DateTime.Now,
            //},
            //new Blog
            //{
            //    Id = 5,
            //    ShortDescription = "That dominion stars lights dominion divide years for fourth have don't stars is that he earth it first without heaven in place seed it second morning saying.",
            //    ImagePath = "single_blog_5.png",
            //    Title = "Google inks pact for new 35-storey office",
            //    isActive = true,
            //    isPopular = false,
            //    Order = 5,
            //    PublishDate = DateTime.Now.AddHours(2),
            //    Description = "MCSE boot camps have its supporters and its detractors. Some people do not understand why you should have to spend money on boot camp when you can get the MCSE study materials yourself at a fraction of the camp price. However, who has the willpower to actually sit through a self-imposed MCSE training. who has the willpower to actually",
            //    WrittenDate = DateTime.Now,
            //});
            #endregion

            #region AuthorList
            //context.Authors.AddOrUpdate(new Author
            //{
            //    Id = 1,
            //    AppUserId = 1,
            //    AuthorName = "Joooniii",
            //    AuthorSurname = "Miyauuu",
            //    Description = "This is the best article i have ever written",
            //    ImagePath = "1.jpg",
            //    UserName = "Ala agilli olda"
            //});
            #endregion

            #region CategoryBlogList
            //context.CategoryBlogs.AddOrUpdate(new CategoryBlog
            //{
            //    Id = 1,
            //    isActive = true,
            //    IsPopular = true,
            //    Name = "Resaurant food",
            //    Order = 1
            //},
            //new CategoryBlog
            //{
            //    Id = 2,
            //    isActive = true,
            //    IsPopular = true,
            //    Name = "Travel news",
            //    Order = 2
            //},
            //new CategoryBlog
            //{
            //    Id = 3,
            //    isActive = true,
            //    IsPopular = false,
            //    Name = "Modern technology",
            //    Order = 3
            //},
            //new CategoryBlog
            //{
            //    Id = 4,
            //    isActive = true,
            //    IsPopular = false,
            //    Name = "Product",
            //    Order = 4
            //},
            //new CategoryBlog
            //{
            //    Id = 5,
            //    isActive = true,
            //    IsPopular = true,
            //    Name = "Inspiration",
            //    Order = 5
            //},
            //new CategoryBlog
            //{
            //    Id = 6,
            //    isActive = true,
            //    IsPopular = true,
            //    Name = "Health Care",
            //    Order = 6
            //});
            #endregion

            #region TagList
            //context.Tags.AddOrUpdate(new Tag
            //{
            //    Id = 1,
            //    IsActive = true,
            //    Order = 1,
            //    Name = "project"
            //},
            //new Tag
            //{
            //    Id = 2,
            //    IsActive = true,
            //    Order = 2,
            //    Name = "love"
            //},
            //new Tag
            //{
            //    Id = 3,
            //    IsActive = true,
            //    Order = 3,
            //    Name = "technology"
            //},
            //new Tag
            //{
            //    Id = 4,
            //    IsActive = true,
            //    Order = 4,
            //    Name = "travel"
            //},
            //new Tag
            //{
            //    Id = 5,
            //    IsActive = true,
            //    Order = 5,
            //    Name = "restaurant"
            //},
            //new Tag
            //{
            //    Id = 6,
            //    IsActive = true,
            //    Order = 6,
            //    Name = "life style"
            //},
            //new Tag
            //{
            //    Id = 7,
            //    IsActive = true,
            //    Order = 7,
            //    Name = "design"
            //},
            //new Tag
            //{
            //    Id = 8,
            //    IsActive = true,
            //    Order = 8,
            //    Name = "illustration"
            //});
            #endregion

            #region ContactList
            //context.Contacts.AddOrUpdate(new Contact
            //{
            //    Id = 1,
            //    Address = "Buttonwood, California.",
            //    Email = "support@colorlib.com",
            //    PhoneNumber = "00(440) 9865 562",
            //    IsActive = true,
            //    Order = 1
            //});
            #endregion

            #region AdminAccountList
            //context.AdminAccounts.AddOrUpdate(new AdminAccount
            //{
            //    Id = 1,
            //    Email = "admin@gmail.com",
            //    Password = "9QM3Kn=v5'KLkh/%"
            //});
            #endregion
        }
    }
}
