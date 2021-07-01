using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Models
{
    public class JobDetailModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string Location { get; set; }

        public string JobDescription { get; set; }

        public decimal WorkDuration { get; set; }

        public DateTime PublisDate { get; set; }

        public DateTime ExpireDate { get; set; }
      
        public int Vacancy { get; set; }

        public string Description { get; set; }

        public string Responsibility { get; set; }

        public string Qualifications { get; set; }

        public string Benefits { get; set; }

        public decimal SalaryFrom { get; set; }

        public decimal SalaryTo { get; set; }
    }
}