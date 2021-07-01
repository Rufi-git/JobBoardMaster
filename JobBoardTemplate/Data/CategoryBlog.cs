using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Data
{
    public class CategoryBlog
    {
        public CategoryBlog()
        {
            Blogs = new HashSet<Blog>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public bool isActive { get; set; }

        [Required]
        public bool IsPopular { get; set; }

        public byte? Order { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}