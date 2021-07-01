using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        //public Founder Founder { get; set; }
        //public int FounderId { get; set; }

        public ICollection<JobModel> Jobs { get; set; }

        //public ICollection<CandidateModel> Candidates { get; set; }
    }
}