using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_Blog.Models
{
    public class BlogModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string description { get; set; }
        public string url { get; set; }
    }
}