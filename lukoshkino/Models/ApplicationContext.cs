using Microsoft.EntityFrameworkCore;

namespace lukoshkino.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<InterfaceTag> InterfaceTags { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Subcategory> Subcategories { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<File> Files { get; set; } = null!;

        public DbSet<Product_Photo> Product_Photos { get; set; } = null!;

        public DbSet<ApplicationUser> Users { get; set; } = null!;

        public DbSet<ApplicationRole> Roles { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=lukoskino.db");
        }
    }
}
