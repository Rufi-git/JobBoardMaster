using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Data
{
    [Table("Founders")]
    public class Founder
    {
        public Founder()
        {
            Companies = new HashSet<Company>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:40,MinimumLength =3)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength:50,MinimumLength =5)]
        public string Occupation { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}