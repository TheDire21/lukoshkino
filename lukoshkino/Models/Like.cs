using System.ComponentModel.DataAnnotations.Schema;

namespace lukoshkino.Models
{
    public class Like
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }

        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
    }
}
