using JobBoardTemplate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public DateTime PublishDate { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public int BlogId { get; set; }
    }
}