using System.ComponentModel.DataAnnotations;

namespace lukoshkino.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
