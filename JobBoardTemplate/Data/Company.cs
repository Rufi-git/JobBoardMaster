using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Data
{
    [Table("Companies")]
    public class Company
    {
        public Company()
        {
            Jobs = new HashSet<Job>();
            Candidates = new HashSet<Candidate>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:40,MinimumLength =4)]
        public string Name { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsTop { get; set; }

        public int? Order { get; set; }

        public Founder Founder { get; set; }
        public int FounderId { get; set; }

        public ICollection<Job> Jobs { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
    }
}