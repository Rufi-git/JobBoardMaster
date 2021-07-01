using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Models
{
    public class CategoryJobModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool isActive { get; set; }

        public int JobCount { get; set; }

        public bool? IsPopular { get; set; }

        public byte? Order { get; set; }

        public ICollection<JobModel> Jobs { get; set; }
    }
}