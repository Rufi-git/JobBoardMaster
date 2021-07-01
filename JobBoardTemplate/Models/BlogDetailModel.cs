using JobBoardTemplate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Models
{
    public class BlogDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime WrittenDate { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<CategoryBlogModel> CategoryBlogs { get; set; }
        public ICollection<TagModel> Tags { get; set; }
    }
}