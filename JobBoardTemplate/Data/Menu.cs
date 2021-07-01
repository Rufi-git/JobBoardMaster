using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Data
{
    [Table("Menus")]
    public class Menu
    {
        public Menu()
        {
            SubMenus = new HashSet<SubMenu>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:30,MinimumLength =2)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public byte? Order { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }

        public ICollection<SubMenu> SubMenus { get; set; }
    }
}