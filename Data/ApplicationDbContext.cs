using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Project.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "T-Shirt" },
                new Category { Id = 2, Name = "Jacket" },
                new Category { Id = 3, Name = "Jeans" },
                new Category { Id = 4, Name = "Trousers" }
                );
            builder.Entity<Product>().HasData(
               new Product { Id = 1, Name = "Tshirt", CategoryId = 1, ImageUrl = "/images/product/shirt.png" }
               );
        }
    }
}