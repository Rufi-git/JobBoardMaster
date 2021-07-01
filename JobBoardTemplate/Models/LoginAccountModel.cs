using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Models
{
    public class LoginAccountModel
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [StringLength(maximumLength: 40, MinimumLength = 8)]
        public string Password { get; set; }
    }
}