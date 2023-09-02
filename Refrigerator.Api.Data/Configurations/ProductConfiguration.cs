using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refrigerator.Api.Data.SeedData;
using Refrigerator.Api.Domain.Models;

namespace Refrigerator.Api.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(RefrigeratorDbSeedData.GetProducts());
        }
    }
}