using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.UserVM;

namespace PermissionBasedAuthentication.Services.UserService
{
	public interface IUserService : IGenericService<User>
	{
		void CreateEntity(UserCreateVM request);
		bool SignIn(string email, string password);
		void SignOut();
		void UpdateEntity(UserUpdateVM request);
	}
}
