using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Data
{
    [Table("Blogs")]
    public class Blog
    {
        public Blog()
        {
            Comments = new HashSet<Comment>();
            CategoryBlogs = new HashSet<CategoryBlog>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Short description")]
        [StringLength(maximumLength: 300, MinimumLength = 5)]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Full Description")]
        [StringLength(maximumLength: 1000, MinimumLength = 5)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        //public virtual HttpPostedFileBase Image { get; set; }

        [Required]
        [Display(Name = "Publish date")]
        public DateTime PublishDate { get; set; }

        [Required]
        [Display(Name = "Written date")]
        public DateTime WrittenDate { get; set; }

        [Required]
        [Display(Name = "Is Active?")]
        public bool isActive { get; set; }

        [Display(Name = "Order")]
        public int? Order { get; set; }

        [Display(Name = "Is Popular?")]
        public bool? isPopular { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<CategoryBlog> CategoryBlogs { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}