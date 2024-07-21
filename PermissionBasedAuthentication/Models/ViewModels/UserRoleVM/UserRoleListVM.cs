using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.RoleVM;
using PermissionBasedAuthentication.Models.ViewModels.UserVM;

namespace PermissionBasedAuthentication.Models.ViewModels.UserRoleVM
{
	public class UserRoleListVM
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public UserListVM User { get; set; }


		public int RoleId { get; set; }
		public RoleListVM Role { get; set; }
	}
}
