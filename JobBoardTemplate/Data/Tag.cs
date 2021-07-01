using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Data
{
    [Table("Tags")]
    public class Tag
    {
        public Tag()
        {
            Blogs = new HashSet<Blog>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:30)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int? Order { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}