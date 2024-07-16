using Microsoft.EntityFrameworkCore;
using PermissionBasedAuthentication.Context;
using PermissionBasedAuthentication.GenericRepositories;
using PermissionBasedAuthentication.Services;
using PermissionBasedAuthentication.Services.UserService;
using System.Reflection;

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

			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
			services.AddScoped<IUserService, UserService>();

			return services;
		}
	}
}
