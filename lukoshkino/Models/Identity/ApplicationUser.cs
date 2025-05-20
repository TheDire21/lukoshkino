using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace lukoshkino.Models
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string? Surname { get; set; }

        public string? Name { get; set; }

        public string? Patronymic { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
