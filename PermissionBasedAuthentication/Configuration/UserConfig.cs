using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionBasedAuthentication.Models.Entity;

namespace PermissionBasedAuthentication.Configuration
{
	public class UserConfig : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Navigation(x => x.UserRoles).AutoInclude();
		}
	}
}
