using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionBasedAuthentication.Models.Entity;

namespace PermissionBasedAuthentication.Configuration
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(x => x.Name).HasMaxLength(50);
			builder.HasData(new Product
			{
				Id = 1,
				Name = "Camera",
				Price = 680.99m,
				Quantity = 5,
				CategoryId = 1
			});

		}
	}
}
