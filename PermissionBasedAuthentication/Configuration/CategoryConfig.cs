using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionBasedAuthentication.Models.Entity;

namespace PermissionBasedAuthentication.Configuration
{
	public class CategoryConfig : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(new Category
			{
				Id = 1,
				Name = "Electronics"
			});
		}
	}
}
