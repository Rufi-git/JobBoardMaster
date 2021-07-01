using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Areas.Admin.Models
{
    public class TagBlogModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int? Order { get; set; }

        public ICollection<ArticleModel> Blogs { get; set; }
    }
}