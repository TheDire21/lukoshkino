using System.ComponentModel.DataAnnotations;

namespace lukoshkino.Models
{
    public class InterfaceTag
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Content { get; set; }
    }
}
