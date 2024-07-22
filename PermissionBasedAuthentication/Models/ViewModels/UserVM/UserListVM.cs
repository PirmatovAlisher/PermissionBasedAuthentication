using PermissionBasedAuthentication.Models.ViewModels.UserRoleVM;

namespace PermissionBasedAuthentication.Models.ViewModels.UserVM
{
	public class UserListVM
	{
		public int Id { get; set; }

		public string FullName { get; set; }

		public string Email { get; set; }

		public ICollection<UserRoleListVM> UserRoles { get; set; }

	}
}
