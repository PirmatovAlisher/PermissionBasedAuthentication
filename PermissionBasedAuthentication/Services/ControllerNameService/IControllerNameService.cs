using PermissionBasedAuthentication.Models.Entity;

namespace PermissionBasedAuthentication.Services.ControllerNameService
{
	public interface IControllerNameService : IGenericService<ControllerName>
	{
		void RefreshControllers();
	}
}
