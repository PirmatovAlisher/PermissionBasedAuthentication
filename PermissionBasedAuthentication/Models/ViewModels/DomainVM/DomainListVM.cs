using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.ControllerVM;
using PermissionBasedAuthentication.Models.ViewModels.RoleVM;

namespace PermissionBasedAuthentication.Models.ViewModels.DomainVM
{
	public class DomainListVM
	{
		public int Id { get; set; }

		public int ControllerNameId { get; set; }

		public ControllerListVM ControllerName { get; set; }


		public int RoleId { get; set; }
		public RoleListVM Role { get; set; }
	}
}
