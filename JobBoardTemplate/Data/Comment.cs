using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Data
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:40,MinimumLength =3)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 500, MinimumLength = 1)]
        public string Text { get; set; }

        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime PublishDate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string Website { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public Blog Blog { get; set; }
        public int BlogId { get; set; }
    }
}