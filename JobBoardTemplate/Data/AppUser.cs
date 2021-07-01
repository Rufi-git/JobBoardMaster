using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Data
{
    [Table("AppUsers")]
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        public byte Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(maximumLength: 600)]
        public string Review { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 40, MinimumLength = 8)]
        public string Password { get; set; }

        public string ImagePath { get; set; }

        public string AboutMe { get; set; }
    }
}