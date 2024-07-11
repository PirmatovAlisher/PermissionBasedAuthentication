using Microsoft.EntityFrameworkCore;
using PermissionBasedAuthentication.Context;
using PermissionBasedAuthentication.GenericRepositories;
using PermissionBasedAuthentication.Services;

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

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

			return services;
		}
	}
}
