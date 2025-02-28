using System.ComponentModel.DataAnnotations;

namespace lukoshkino.Models
{
    public class ApplicationRole
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
