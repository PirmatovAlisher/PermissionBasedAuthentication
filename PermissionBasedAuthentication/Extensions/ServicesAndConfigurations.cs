using Microsoft.AspNetCore.Authentication.Cookies;
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


			services.AddHttpContextAccessor();

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
			{
				var newCookie = new CookieBuilder();
				newCookie.Name = "DynamicAuth";
				options.Cookie.HttpOnly = true;
				options.Cookie.SameSite = SameSiteMode.Strict;
				options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
				options.LoginPath = "/Authenticate/Login";
				options.LogoutPath = "/Authenticated/Logout";
				//options.AccessDeniedPath = "/";
				options.Cookie = newCookie;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
			});

			return services;
		}
	}
}
