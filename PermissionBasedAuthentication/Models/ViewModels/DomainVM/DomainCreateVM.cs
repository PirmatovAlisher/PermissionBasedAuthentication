using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.RoleVM;

namespace PermissionBasedAuthentication.Models.ViewModels.DomainVM
{
	public class DomainCreateVM
	{
		public int ControllerNameId { get; set; }

		public int RoleId { get; set; }



		public string ControllerNameForTitle { get; set; }

		public List<RoleListVM> Roles { get; set; }
	}
}
