using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Areas.Admin.Models
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "no email, no entrance")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "no password, no entrance")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 40, MinimumLength = 8)]
        public string Password { get; set; }
    }
}