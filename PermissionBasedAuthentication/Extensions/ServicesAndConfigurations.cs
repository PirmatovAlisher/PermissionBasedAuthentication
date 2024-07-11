using Microsoft.EntityFrameworkCore;
using PermissionBasedAuthentication.Context;

namespace PermissionBasedAuthentication.Extensions
{
	public static class ServicesAndConfigurations
	{
		public static IServiceCollection LoadServicesAndConfigs(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<CustomContext>(opt =>
			{
				opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			});

			return services;
		}
	}
}
