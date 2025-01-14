using System.ComponentModel.DataAnnotations;

namespace StudentAppWithLogin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Login Id is required")]
        public string LoginId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
