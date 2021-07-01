using FluentValidation.Results;
using JobBoardTemplate.AppCode;
using JobBoardTemplate.Areas.Admin.Models;
using JobBoardTemplate.Controllers;
using JobBoardTemplate.Data;
using JobBoardTemplate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace JobBoardTemplate.Infrastructure
{
    public static class DbContextExtension
    {
        public static IEnumerable<MenuModel> AllMenus(this JobDbContext jobDbContext)
        {
            return jobDbContext.Menus.OrderBy(x => x.Order).Where(x => x.IsActive == true).Select(y => new MenuModel
            {
                Id = y.Id,
                ActionName = y.ActionName,
                ControllerName = y.ControllerName,
                Name = y.Name,
                SubMenus = y.SubMenus.Select(s => new SubMenuModel
                {
                    Id = s.Id,
                    ActionName = s.ActionName,
                    ControllerName = s.ControllerName,
                    Name = s.Name,
                    MenuId = s.MenuId
                }).ToList()
            }).ToList();
        }

        public static IEnumerable<TestimonialModel> GetTestimonialUsers(this JobDbContext jobDbContext)
        {
            return jobDbContext.AppUsers.Where(x => x.Review != null)
                .Select(t => new TestimonialModel
                {
                    Id = t.Id,
                    Surname = t.Surname,
                    ImagePath = t.ImagePath,
                    Name = t.Name,
                    Review = t.Review
                }).ToList();
        }

        public static IEnumerable<CandidateModel> GetCandidates(this JobDbContext jobDbContext)
        {
            return jobDbContext.Candidates.Include("Companies").Include("Jobs").OrderBy(x => x.Order).Where(y => y.IsActive == true)
                .Select(c => new CandidateModel
                {
                    Id = c.Id,
                    Occupation = c.Occupation,
                    Companies = c.Companies.Select(v => new CompanyModel
                    {
                        Id = v.Id,
                        ImagePath = v.ImagePath,
                        Name = v.Name
                    }).ToList(),
                    Jobs = c.Jobs.Select(j => new JobModel
                    {
                        Id = j.Id,
                        ImagePath = j.ImagePath,
                        Location = j.Location,
                        Name = j.Name,
                        PublisDate = j.PublisDate,
                        WorkDuration = j.WorkDuration
                    }).ToList(),
                    AppUser = c.AppUser,
                    AppUserId = c.AppUserId
                }).ToList();
        }

        public async static Task<CandidateModel> GetCandidateDetailAsync(this JobDbContext jobDbContext, int id)
        {
            var candidate = await jobDbContext.Candidates.Include("Jobs").Include("Companies")
               .Select(c => new CandidateModel
               {
                   Id = c.Id,
                   Occupation = c.Occupation,
                   AppUser = c.AppUser,
                   AppUserId = c.AppUserId,
                   Companies = c.Companies.Select(m => new CompanyModel
                   {
                       Id = m.Id,
                       ImagePath = m.ImagePath,
                       Name = m.Name
                   }).ToList(),
                   Jobs = c.Jobs.Select(z => new JobModel
                   {
                       Id = z.Id,
                       ImagePath = z.ImagePath,
                       Location = z.Location,
                       Name = z.Name,
                       PublisDate = z.PublisDate,
                       WorkDuration = z.WorkDuration
                   }).ToList()
               }).FirstOrDefaultAsync(x => x.Id == id);

            if (candidate == null)
            {
                return null;
            }

            return candidate;
        }

        public static IEnumerable<CategoryJobModel> GetPopularJobCategories(this JobDbContext jobDbContext)
        {
            return jobDbContext.CategoryJobs.Include("Jobs").OrderBy(o => o.Order).Where(x => x.IsPopular == true)
               .Select(c => new CategoryJobModel
               {
                   Id = c.Id,
                   Name = c.Name,
                   isActive = true,
                   IsPopular = true,
                   Order = 1,
                   Jobs = c.Jobs.Select(j => new JobModel
                   {
                       Id = j.Id,
                       Name = j.Name,
                       Location = j.Location,
                       PublisDate = j.PublisDate,
                       WorkDuration = j.WorkDuration,
                       ImagePath = j.ImagePath
                   }).ToList()
               }).ToList();
        }

        public static IEnumerable<CategoryJobModel> GetPopularToSearch(this JobDbContext jobDbContext)
        {
            return jobDbContext.CategoryJobs.OrderBy(o => o.Order).Where(x => x.IsPopular == true)
              .Select(c => new CategoryJobModel
              {
                  Id = c.Id,
                  Name = c.Name,
                  isActive = true,
                  IsPopular = true,
                  Order = 1,
              }).ToList();
        }

        public async static Task<CategoryJobModel> GetCategoryJobDetailAsync(this JobDbContext jobDbContext, int id)
        {
            var category = await jobDbContext.CategoryJobs.Include("Jobs")
                .Select(a => new CategoryJobModel
                {
                    Id = a.Id,
                    isActive = a.IsActive,
                    IsPopular = a.IsPopular,
                    JobCount = a.Jobs.Count(),
                    Order = a.Order,
                    Jobs = a.Jobs.Select(j => new JobModel
                    {
                        Id = j.Id,
                        ImagePath = j.ImagePath,
                        Location = j.Location,
                        Name = j.Name,
                        PublisDate = j.PublisDate,
                        WorkDuration = j.WorkDuration
                    }).ToList()
                }).FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return null;
            }

            return category;
        }

        public static IEnumerable<CompanyModel> GetTopCompanies(this JobDbContext jobDbContext)
        {
            return jobDbContext.Companies.Include("Jobs").OrderBy(x => x.Order).Where(x => x.IsTop == true && x.IsActive == true)
                .Select(c => new CompanyModel
                {
                    Id = c.Id,
                    ImagePath = c.ImagePath,
                    Name = c.Name,
                    Jobs = c.Jobs.Select(j => new JobModel
                    {
                        Id = j.Id,
                        ImagePath = j.ImagePath,
                        Name = j.Location,
                    }).ToList()
                }).ToList();
        }

        public async static Task<CompanyDetailModel> GetCompanyDetailAsync(this JobDbContext jobDbContext, int id)
        {
            var company = await jobDbContext.Companies.Include("Candidates").Include("Jobs").Select(c => new CompanyDetailModel
            {
                Id = c.Id,
                Name = c.Name,
                ImagePath = c.ImagePath,
                Founder = c.Founder,
                FounderId = c.FounderId,
                Location = c.Location,
                Candidates = c.Candidates.Select(h => new CandidateModel
                {
                    Id = h.Id,
                    Occupation = h.Occupation,
                }).ToList(),
                Jobs = c.Jobs.Select(s => new JobModel
                {
                    Id = s.Id,
                    ImagePath = s.ImagePath,
                    Location = s.Location,
                    Name = s.Name,
                    PublisDate = s.PublisDate,
                    WorkDuration = s.WorkDuration
                }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == id);

            if (company == null)
            {
                return null;
            }

            return company;
        }

        public static IEnumerable<JobModel> GetAllJobs(this JobDbContext jobDbContext)
        {
            return jobDbContext.Jobs.OrderBy(x => x.Order).Select(j => new JobModel
            {
                Id = j.Id,
                ImagePath = j.ImagePath,
                Location = j.Location,
                Name = j.Name,
                PublisDate = j.PublisDate,
                WorkDuration = j.WorkDuration,
            }).ToList();
        }

        public async static Task<JobDetailModel> GetJobDetailAsync(this JobDbContext jobDbContext, int id)
        {
            var job = await jobDbContext.Jobs.Select(s => new JobDetailModel
            {
                Id = s.Id,
                ImagePath = s.ImagePath,
                Location = s.Location,
                Name = s.Name,
                PublisDate = s.PublisDate,
                WorkDuration = s.WorkDuration,
                Benefits = s.Benefits,
                SalaryFrom = s.SalaryFrom,
                SalaryTo = s.SalaryTo,
                Description = s.Description,
                ExpireDate = s.ExpireDate,
                JobDescription = s.Description,
                Qualifications = s.Qualifications,
                Responsibility = s.Responsibility,
                Vacancy = s.Vacancy
            }).FirstOrDefaultAsync(x => x.Id == id);
            if (job == null)
            {
                return null;
            }
            return job;
        }

        public static IEnumerable<JobModel> GetSliderJob(this JobDbContext jobDbContext)
        {
            return jobDbContext.Jobs.Select(s => new JobModel
            {
                Id = s.Id
            }).ToList();
        }

        public static IEnumerable<BlogModel> GetArticles(this JobDbContext jobDbContext, int page, int itemsPerPage)
        {
            return jobDbContext.Blogs.Include("Comments").Include("CategoryBlogs").Include("Tags").OrderBy(a => a.Order).Where(b => b.isActive == true)
                 .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(a => new BlogModel
                {
                    Id = a.Id,
                    ShortDescription = a.ShortDescription,
                    ImagePath = a.ImagePath,
                    Title = a.Title,
                    PublishDate = a.PublishDate,
                    CategoryBlog = a.CategoryBlogs.Select(c => new CategoryBlogModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList(),
                    Comments = a.Comments.Select(g => new CommentModel
                    {
                        Id = g.Id,
                        PublishDate = g.PublishDate,
                        Email = g.Email,
                        Website = g.Website,
                        Name = g.Name,
                        Text = g.Text,
                        BlogId = g.BlogId
                    }).ToList(),
                    Tags = a.Tags.Select(t => new TagModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                    }).ToList()
                }).ToList();
        }

        public static IEnumerable<CategoryBlogModel> GetCategoryBlogs(this JobDbContext jobDbContext)
        {
            return jobDbContext.CategoryBlogs.Include("Blogs").Where(x => x.isActive == true)
                .OrderBy(o => o.Order).Select(c => new CategoryBlogModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Blogs = c.Blogs.Select(b => new BlogModel
                    {
                        Id = b.Id,
                        ShortDescription = b.ShortDescription,
                        PublishDate = b.PublishDate,
                        Title = b.Title,
                        ImagePath = b.ImagePath,

                    }).ToList()
                }).ToList();

        }

        public async static Task<BlogDetailModel> GetBlogDetailAsync(this JobDbContext jobDbContext, int id)
        {
            var blog = await jobDbContext.Blogs.Include("Comments").Include("CategoryBlogs").Include("Tags").OrderBy(a => a.Order).Where(b => b.isActive == true)
              .Select(a => new BlogDetailModel
              {
                  Id = a.Id,
                  ShortDescription = a.ShortDescription,
                  ImagePath = a.ImagePath,
                  Title = a.Title,
                  PublishDate = a.PublishDate,
                  Description = a.Description,
                  WrittenDate = a.WrittenDate,
                  CategoryBlogs = a.CategoryBlogs.Select(c => new CategoryBlogModel
                  {
                      Id = c.Id,
                      Name = c.Name,
                  }).ToList(),
                  Comments = a.Comments.Select(g => new CommentModel
                  {
                      Id = g.Id,
                      PublishDate = g.PublishDate,
                      Email = g.Email,
                      Website = g.Website,
                      Name = g.Name,
                      Text = g.Text,
                      ImagePath = g.ImagePath,
                      BlogId = g.BlogId,
                      IsActive = g.IsActive,
                  }).ToList(),
                  Tags = a.Tags.Select(t => new TagModel
                  {
                      Id = t.Id,
                      Name = t.Name,
                  }).ToList(),
              }).FirstOrDefaultAsync(f => f.Id == id);
            if (blog == null)
            {
                return null;
            }
            return blog;
        }

        public static IEnumerable<BlogModel> GetPopularBlogs(this JobDbContext jobDbContext)
        {
            return jobDbContext.Blogs.Where(x => x.isActive == true && x.isPopular == true)
                 .OrderBy(y => y.Order).Select(s => new BlogModel
                 {
                     Id = s.Id,
                     Title = s.Title,
                     ImagePath = s.ImagePath,
                     PublishDate = s.PublishDate,
                 }).ToList();
        }

        public static IEnumerable<BlogModel> GetFeeds(this JobDbContext jobDbContext)
        {
            return jobDbContext.Blogs.Where(x => x.isActive == true).OrderBy(o => o.Order)
                .Select(s => new BlogModel
                {
                    Id = s.Id,
                    ImagePath = s.ImagePath
                }).ToList();
        }

        public async static Task<CategoryBlogModel> GetCategoryBlogDetailAsync(this JobDbContext jobDbContext, int id)
        {
            var blog = await jobDbContext.CategoryBlogs.Include("Comments").Include("Blogs").Select(c => new CategoryBlogModel
            {
                Id = c.Id,
                Name = c.Name,
                Blogs = c.Blogs.Select(b => new BlogModel
                {
                    ShortDescription = b.ShortDescription,
                    Id = b.Id,
                    PublishDate = b.PublishDate,
                    ImagePath = b.ImagePath,
                    Title = b.Title,
                    Comments = b.Comments.Select(a => new CommentModel
                    {
                        Id = b.Id,
                    }).ToList(),
                }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == id);

            if (blog == null)
            {
                return null;
            }

            return blog;
        }

        public static void CommentAdd(this JobDbContext jobDbContext, CommentModel comment)
        {
            comment.PublishDate = DateTime.UtcNow;
            comment.ImagePath = "2.jpg";
            Comment c = new Comment
            {
                BlogId = comment.BlogId,
                Email = comment.Email,
                Name = comment.Name,
                Text = comment.Text,
                PublishDate = comment.PublishDate,
                Website = comment.Website,
                ImagePath = comment.ImagePath
            };
            jobDbContext.Comments.Add(c);
            jobDbContext.SaveChangesAsync();
        }

        public static IEnumerable<TagModel> GetTags(this JobDbContext jobDbContext)
        {
            return jobDbContext.Tags.Include("Blogs").Where(x => x.IsActive == true).OrderBy(y => y.Order)
                .Select(t => new TagModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Blogs = t.Blogs.Select(b => new BlogModel
                    {
                        Id = b.Id,
                    }).ToList()
                }).ToList();
        }

        public async static Task<TagModel> GetTagDetailAsync(this JobDbContext jobDbContext, int id)
        {
            var tag = await jobDbContext.Tags.Include("Blogs").Where(x => x.IsActive == true).OrderBy(y => y.Order)
                .Select(t => new TagModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Blogs = t.Blogs.Select(b => new BlogModel
                    {
                        ShortDescription = b.ShortDescription,
                        Id = b.Id,
                        PublishDate = b.PublishDate,
                        ImagePath = b.ImagePath,
                        Title = b.Title,
                    }).ToList()
                }).FirstOrDefaultAsync(x => x.Id == id);

            if (tag == null)
            {
                return null;
            }

            return tag;
        }

        public static IEnumerable<ContactModel> GetContacts(this JobDbContext jobDbContext)
        {
            return jobDbContext.Contacts.Where(x => x.IsActive == true)
                .OrderBy(o => o.Order).Select(c => new ContactModel
                {
                    Id = c.Id,
                    Address = c.Address,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber
                }).ToList();
        }

        public static void AccountRegister(this JobDbContext jobDbContext, RegisterModel register)
        {
            AppUser user = new AppUser
            {
                Id = register.Id,
                Surname = register.Surname,
                AboutMe = register.AboutMe,
                Age = register.Age,
                Email = register.Email,
                Gender = register.Gender.ToString(),
                ImagePath = register.ImagePath,
                Name = register.Name,
                Password = register.Password,
                Review = register.Review,
                UserName = register.UserName,
            };

            jobDbContext.AppUsers.Add(user);
            jobDbContext.SaveChanges();
        }

        //-----------------------------------AdminPanel Extensions-----------------------------------------

        public static AdminAccount UserExists(this DbSet<AdminAccount> user, LoginModel loginModel)
        {
            return user.Where(x => x.Email == loginModel.Email && x.Password == loginModel.Password).SingleOrDefault();
        }

        public async static Task<ArticleModel> EditBlogAsync(this JobDbContext jobDbContext, int id)
        {
            return await jobDbContext.Blogs.Include("Comments").Select(b => new ArticleModel
            {
                Id = b.Id,
                Description = b.Description,
                ImagePath = b.ImagePath,
                isActive = b.isActive,
                isPopular = b.isPopular,
                PublishDate = b.PublishDate,
                ShortDescription = b.ShortDescription,
                Order = b.Order,
                WrittenDate = b.WrittenDate,
                Title = b.Title,
                Comments = b.Comments.Select(c => new CommentModel
                {
                    Id = c.Id,
                    Email = c.Email,
                    Name = c.Name,
                    PublishDate = c.PublishDate,
                    ImagePath = c.ImagePath,
                    Text = c.Text,
                    Website = c.Website,
                    IsActive = c.IsActive
                }).ToList(),
                Tags = b.Tags.Select(t => new TagBlogModel
                {
                    Id = t.Id,
                    IsActive = t.IsActive,
                    Name = t.Name,
                    Order = t.Order,
                }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public static void AddAdminBlog(this JobDbContext jobDbContext, ArticleModel articleModel, int id)
        {
            var allArticles = jobDbContext.Blogs.ToList();

            articleModel.PublishDate = DateTime.Now;
            articleModel.WrittenDate = DateTime.Now;
            Blog article = new Blog
            {
                Id = articleModel.Id,
                Description = articleModel.Description,
                ShortDescription = articleModel.ShortDescription,
                isActive = articleModel.isActive,
                ImagePath = articleModel.ImagePath,
                isPopular = articleModel.isPopular,
                Order = articleModel.Order,
                PublishDate = articleModel.PublishDate,
                Title = articleModel.Title,
                WrittenDate = articleModel.WrittenDate,
            };
            if (article.Order == null || article.Order == 0)
            {
                article.Order = allArticles.Count() + 1;
            }
            Tag categoryJob = jobDbContext.Tags.FirstOrDefault(x => x.Id == id);
            jobDbContext.Blogs.Add(article).Tags.Add(categoryJob);
            jobDbContext.SaveChanges();
        }

        public static void DeleteAdminBlog(this JobDbContext jobDbContext, int id)
        {
            var deletedBlog = jobDbContext.Blogs.Find(id);
            var deletedComments = jobDbContext.Comments.ToList();
            foreach (var comment in deletedComments)
            {
                bool find = comment.BlogId == deletedBlog.Id;
                if (find)
                {
                    jobDbContext.Comments.Remove(comment);
                    jobDbContext.SaveChanges();
                }
            }
        }

        public static CategoryModel EditAdminCategoryJob(this JobDbContext jobDbContext, int id)
        {
            return jobDbContext.CategoryJobs.OrderBy(x => x.Order).Include("Jobs").Select(f => new CategoryModel
            {
                Id = f.Id,
                IsActive = f.IsActive,
                IsPopular = f.IsPopular,
                Name = f.Name,
                Order = f.Order,
                Jobs = f.Jobs.Select(j => new JobCategoryModel
                {
                    Id = j.Id,
                    ImagePath = j.ImagePath,
                    Location = j.Location,
                    PublisDate = j.PublisDate,
                    WorkDuration = j.WorkDuration,
                    Name = j.Name,
                    ExpireDate = j.ExpireDate,
                    IsActive = j.IsActive,
                    Order = j.Order,
                    SalaryFrom = j.SalaryFrom,
                    SalaryTo = j.SalaryTo,
                    Benefits = j.Benefits,
                    Description = j.Description,
                    Qualifications = j.Qualifications,
                    Responsibility = j.Responsibility,
                    Vacancy = j.Vacancy
                }).OrderBy(a => a.Order).ToList()
            }).FirstOrDefault(x => x.Id == id);
        }

        public static void AdminCommentAdd(this JobDbContext jobDbContext, CommentBlogModel commentModel)
        {
            commentModel.PublishDate = DateTime.Now;
            Comment comment = new Comment
            {
                Email = commentModel.Email,
                ImagePath = commentModel.ImagePath,
                IsActive = commentModel.IsActive,
                Name = commentModel.Name,
                PublishDate = commentModel.PublishDate,
                Text = commentModel.Text,
                Website = commentModel.Website,
                BlogId = commentModel.BlogId,
            };
            jobDbContext.Comments.Add(comment);
            jobDbContext.SaveChanges();
        }

        public async static Task<CommentBlogModel> EditAdminCommentGet(this JobDbContext jobDbContex, int id)
        {
            return await jobDbContex.Comments.Select(a => new CommentBlogModel
            {
                Id = a.Id,
                PublishDate = a.PublishDate,
                Email = a.Email,
                ImagePath = a.ImagePath,
                Name = a.Name,
                Text = a.Text,
                Website = a.Website,
                IsActive = a.IsActive,
                BlogId = a.BlogId,
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public static void EditAdminCommentPost(this JobDbContext jobDbContex, CommentBlogModel commentModel)
        {
            commentModel.PublishDate = DateTime.Now;
            var editableComment = jobDbContex.Comments.Find(commentModel.Id);

            jobDbContex.Entry(editableComment).CurrentValues.SetValues(commentModel);
            jobDbContex.SaveChanges();
        }

        public static IEnumerable<CommentBlogModel> AdminCommentNotInBlog(this JobDbContext jobDbContex, int id)
        {
            var comments = jobDbContex.Comments.Select(x => new CommentBlogModel
            {
                Id = x.Id,
                BlogId = x.BlogId,
                Email = x.Email,
                ImagePath = x.ImagePath,
                IsActive = x.IsActive,
                Name = x.Name,
                PublishDate = x.PublishDate,
                Text = x.Text,
                Website = x.Website
            }).Where(x => x.BlogId != id).ToList();

            return comments;
        }

        public async static Task<IEnumerable<TagBlogModel>> AdminTag(this JobDbContext jobDbContex)
        {
            var tags = await jobDbContex.Tags.OrderBy(o => o.Order).Select(t => new TagBlogModel
            {
                Id = t.Id,
                IsActive = t.IsActive,
                Name = t.Name,
                Order = t.Order,

            }).ToListAsync();

            return tags;
        }

        public static void EditAdminJob(this JobDbContext jobDbContex, JobCategoryModel jobCategoryModel)
        {
            jobCategoryModel.PublisDate = DateTime.UtcNow;
            jobCategoryModel.ExpireDate = DateTime.UtcNow;

            var editableJob = jobDbContex.Jobs.Find(jobCategoryModel.Id);
            jobDbContex.Entry(editableJob).CurrentValues.SetValues(jobCategoryModel);
            jobDbContex.SaveChanges();
        }

        public static Job AddAdminJob(this JobDbContext jobDbContex, JobCategoryModel jobCategoryModel)
        {
            return new Job
            {
                Id = jobCategoryModel.Id,
                SalaryFrom = jobCategoryModel.SalaryFrom,
                SalaryTo = jobCategoryModel.SalaryTo,
                Benefits = jobCategoryModel.Benefits,
                Description = jobCategoryModel.Description,
                ExpireDate = jobCategoryModel.ExpireDate,
                ImagePath = jobCategoryModel.ImagePath,
                IsActive = jobCategoryModel.IsActive,
                Location = jobCategoryModel.Location,
                Name = jobCategoryModel.Name,
                Order = jobCategoryModel.Order,
                PublisDate = jobCategoryModel.PublisDate,
                Qualifications = jobCategoryModel.Qualifications,
                Responsibility = jobCategoryModel.Responsibility,
                Vacancy = jobCategoryModel.Vacancy,
                WorkDuration = jobCategoryModel.WorkDuration,
            };
        }
    }
}