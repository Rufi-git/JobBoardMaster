using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Data
{
    [Table("Candidates")]
    public class Candidate
    {
        public Candidate()
        {
            Jobs = new HashSet<Job>();
            Companies = new HashSet<Company>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 3)]
        public string Occupation { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int? Order { get; set; }

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }

        public ICollection<Job> Jobs { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}