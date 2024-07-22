using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionBasedAuthentication.Models.Entity;

namespace PermissionBasedAuthentication.Configuration
{
	public class ControllerNameConfig : IEntityTypeConfiguration<ControllerName>
	{
		public void Configure(EntityTypeBuilder<ControllerName> builder)
		{
			builder.Navigation(x => x.Domains).AutoInclude();
		}
	}
}
