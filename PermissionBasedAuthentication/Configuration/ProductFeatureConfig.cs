using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionBasedAuthentication.Models.Entity;

namespace PermissionBasedAuthentication.Configuration
{
	public class ProductFeatureConfig : IEntityTypeConfiguration<ProductFeature>
	{
		public void Configure(EntityTypeBuilder<ProductFeature> builder)
		{
			builder.HasData(new ProductFeature
			{
				Id = 1,
				Weight = 1.5,
				Height = 35.56,
				ProductId = 1,
				Color = "Black"
			});
		}
	}
}
