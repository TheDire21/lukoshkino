using System.ComponentModel.DataAnnotations;

namespace lukoshkino.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public bool IsActive { get; set; }
    }
}
