using JobBoardTemplate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Areas.Admin.Models
{
    public class CommentBlogModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime PublishDate { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int BlogId { get; set; }
    }
}