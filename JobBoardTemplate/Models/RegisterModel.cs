using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }

        [StringLength(maximumLength:50,MinimumLength =3)]
        public string UserName { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFileBase Image { get; set; }

        public string AboutMe { get; set; }

        public string Review { get; set; }


        public Gender Gender { get; set; }

        public byte Age { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}