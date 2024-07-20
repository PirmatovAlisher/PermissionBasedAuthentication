using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionBasedAuthentication.Models.Entity;

namespace PermissionBasedAuthentication.Configuration
{
	public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			builder.Navigation(x => x.Role).AutoInclude();
		}
	}
}
