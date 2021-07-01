using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Areas.Admin.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool? IsPopular { get; set; }

        public byte? Order { get; set; }

        public ICollection<JobCategoryModel> Jobs { get; set; }
    }
}