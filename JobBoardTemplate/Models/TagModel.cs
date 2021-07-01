using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BlogModel> Blogs { get; set; }
    }
}