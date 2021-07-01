using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Data
{
    public class SubMenu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public byte? Order { get; set; }

        [Required]
        public string ActionName { get; set; }

        [Required]
        public string ControllerName { get; set; }

        public Menu Menu { get; set; }
        public int MenuId { get; set; }
    }
}