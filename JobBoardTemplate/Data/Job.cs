using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Data
{
    [Table("Jobs")]
    public class Job
    {
        public Job()
        {
            Companies = new HashSet<Company>();
            CategoryJobs = new HashSet<CategoryJob>();
            Candidates = new HashSet<Candidate>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public decimal WorkDuration { get; set; }

        [Required]
        public DateTime PublisDate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int? Order { get; set; }

        [Required]
        public int Vacancy { get; set; }

        [Required]
        [StringLength(maximumLength:800)]
        public string Description { get; set; }

        [Required]
        [StringLength(maximumLength: 500)]
        public string Responsibility { get; set; }
        
        [Required]
        [StringLength(maximumLength: 500)]
        public string Qualifications { get; set; }

        [Required]
        [StringLength(maximumLength: 600)]
        public string Benefits { get; set; }

        [Required]
        public decimal SalaryFrom { get; set; }

        [Required]
        public decimal SalaryTo { get; set; }

        public ICollection<Company> Companies { get;set; }
        public ICollection<CategoryJob> CategoryJobs { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
    }
}