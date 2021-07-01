using JobBoardTemplate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Models
{
    public class CandidateModel
    {
        public int Id { get; set; }

        public string Occupation { get; set; }

        public ICollection<JobModel> Jobs { get; set; }

        public ICollection<CompanyModel> Companies { get; set; }

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}