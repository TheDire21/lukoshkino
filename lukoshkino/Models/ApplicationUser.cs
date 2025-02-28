using System.ComponentModel.DataAnnotations;

namespace lukoshkino.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public int ApplicationRoleId { get; set; }

        [Required]
        public ApplicationRole? ApplicationRole { get; set; }
    }
}
