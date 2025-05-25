using System.ComponentModel.DataAnnotations.Schema;

namespace lukoshkino.Models
{
    public class Order
    {
        public int Id { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        public int OrderStatusId { get; set; }

        public OrderStatus? OrderStatus { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
