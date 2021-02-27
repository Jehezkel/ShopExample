using Shop.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Shop.Api.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

    }
}