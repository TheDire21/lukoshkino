using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lukoshkino.Models
{
	[PrimaryKey("ProductId", new string[] {"UserId"})]
	public class Like
    {
        
        public int ProductId { get; set; }
		
		public Product? Product { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
    }
}
