using System.ComponentModel.DataAnnotations;

namespace lukoshkino.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";

        [Required]
        [StringLength(100, ErrorMessage = "Символ {0} должен быть не менее {2} и не более {1} символов в длину.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = "";

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Пароль и пароль подтверждения не совпадают.")]
        public string ConfirmPassword { get; set; } = "";

    }
}
