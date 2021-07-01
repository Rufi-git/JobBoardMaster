using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Models
{
    public class AppUserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Come on, you have username, don't you?")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Come on, you have name, don't you?")]
        [StringLength(maximumLength: 40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Come on, you have surname, don't you?")]
        [StringLength(maximumLength: 40, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Come on, you have age, don't you?")]
        public byte Age { get; set; }

        [Required(ErrorMessage = "Please Enter Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Come on, you have username, don't you?")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [StringLength(maximumLength: 600)]
        public string Review { get; set; }

        [Required(ErrorMessage = "Come on, you have password, don't you?")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 40, MinimumLength = 8)]
        public string Password { get; set; }

        public string ImagePath { get; set; }

        public string AboutMe { get; set; }
    }
}