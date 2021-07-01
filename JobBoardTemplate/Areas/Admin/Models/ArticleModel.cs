using JobBoardTemplate.Data;
using JobBoardTemplate.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Areas.Admin.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public HttpPostedFileBase Image { get; set; }


        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public DateTime WrittenDate { get; set; }

        [Required]
        public bool isActive { get; set; }

        public int? Order { get; set; }

        public bool? isPopular { get; set; }

        public ICollection<JobBoardTemplate.Models.CommentModel> Comments { get; set; }
        public ICollection<TagBlogModel> Tags { get; set; }
    }
}