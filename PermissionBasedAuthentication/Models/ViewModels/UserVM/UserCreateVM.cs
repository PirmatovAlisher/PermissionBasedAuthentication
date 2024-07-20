using PermissionBasedAuthentication.Models.Entity;

namespace PermissionBasedAuthentication.Models.ViewModels.UserVM
{
	public class UserCreateVM
	{
		public string FullName { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public string ConfirmPassword { get; set; }

		public ICollection<UserRole> UserRoles { get; set; }
	}
}
