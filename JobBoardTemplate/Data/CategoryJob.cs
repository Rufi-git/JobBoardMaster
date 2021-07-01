using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Data
{
    [Table("CategoryJobs")]
    public class CategoryJob
    {
        public CategoryJob()
        {
            Jobs = new HashSet<Job>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public bool? IsPopular { get; set; }

        public byte? Order { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}