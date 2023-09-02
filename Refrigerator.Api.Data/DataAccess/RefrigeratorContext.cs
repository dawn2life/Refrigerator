using Microsoft.EntityFrameworkCore;
using Refrigerator.Api.Data.Configurations;
using Refrigerator.Api.Domain.Models;

namespace Refrigerator.Api.Data.DataAccess
{
    public class RefrigeratorContext : DbContext
    {
        public RefrigeratorContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<FridgeActivityLog> FridgeActivityLogs { get; set; }
    }
}
