using System.ComponentModel.DataAnnotations;

namespace lukoshkino.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public bool isActive { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public bool isPopular { get; set; }
        public bool isLike { get; set; }
    }
}
