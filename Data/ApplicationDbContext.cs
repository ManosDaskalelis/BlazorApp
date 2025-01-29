using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }

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
                new Product { Id = 100, Name = "Tshirt", CategoryId = 4, ImageUrl = "/images/product/shirt.png", Price = 19.99m, SpecialTag = "New", Description = "Comfortable cotton t-shirt" },
                new Product { Id = 101, Name = "Jacket", CategoryId = 8, ImageUrl = "/images/product/shirt.png", Price = 49.99m, SpecialTag = "Sale", Description = "Warm winter jacket" },
                new Product { Id = 102, Name = "Jeans", CategoryId = 9, ImageUrl = "/images/product/shirt.png", Price = 39.99m, Description = "Stylish denim jeans" },
                new Product { Id = 103, Name = "Trousers", CategoryId = 10, ImageUrl = "/images/product/shirt.png", Price = 29.99m, Description = "Classic formal trousers" }
            );
        }
    }
}