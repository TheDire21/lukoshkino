using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lukoshkino.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        public DbSet<InterfaceTag> InterfaceTags { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<File> Files { get; set; } = null!;

        public DbSet<Product_Photo> Product_Photos { get; set; } = null!;

        public DbSet<Like> Likes { get; set; } = null!;

        public DbSet<Basket> Baskets { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        public DbSet<OrderStatus> orderStatuses { get; set; } = null!;

    }
}
