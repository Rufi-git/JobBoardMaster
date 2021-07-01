using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Models
{
    public class JobModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string Location { get; set; }

        public decimal WorkDuration { get; set; }

        public DateTime PublisDate { get; set; }
    }
}