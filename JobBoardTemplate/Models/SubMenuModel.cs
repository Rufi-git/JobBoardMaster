using JobBoardTemplate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Models
{
    public class SubMenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public Menu Menu { get; set; }
        public int MenuId { get; set; }
    }
}