using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lukoshkino.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        public bool isInHome { get; set; }

    }
}
