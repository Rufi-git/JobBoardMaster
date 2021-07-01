using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Data
{
    public class JobDbContext:DbContext
    {
        public JobDbContext() : base("JobDbConnectionString") { }

        public DbSet<AdminAccount> AdminAccounts { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CategoryJob> CategoryJobs { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Founder> Founders { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}