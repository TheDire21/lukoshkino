using lukoshkino.Models;
using System.ComponentModel.DataAnnotations;

namespace lukoshkino.ViewModels
{
    public class LoginModel
    {
        public string Email { get; set; } = "";

        public string Password { get; set; } = "";

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
