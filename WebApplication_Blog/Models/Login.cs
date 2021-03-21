using System.ComponentModel.DataAnnotations;

namespace WebApplication_Blog.Models
{
    public class Login
    {
        [Display(Name = "User Id")]
        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}