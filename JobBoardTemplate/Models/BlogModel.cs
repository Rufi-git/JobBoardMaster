using JobBoardTemplate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Models
{
    public class BlogModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title can not be null")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Short description can not be null")]
        public string ShortDescription { get; set; }

        public string ImagePath { get; set; }
        public DateTime PublishDate { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<CategoryBlogModel> CategoryBlog { get; set; }
        public ICollection<TagModel> Tags { get; set; }
    }
}