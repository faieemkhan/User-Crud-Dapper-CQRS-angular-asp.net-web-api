using System.ComponentModel.DataAnnotations;

namespace UserCrudWithAspDotNetCoreWithAngular.Model
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string? Password { get; set; }
    }
}
