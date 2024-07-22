using PermissionBasedAuthentication.Models.ViewModels.ControllerVM;
using PermissionBasedAuthentication.Models.ViewModels.RoleVM;

namespace PermissionBasedAuthentication.Models.ViewModels.DomainVM
{
	public class DomainUpdateVM
	{
		public int Id { get; set; }

		public int ControllerNameId { get; set; }

		public int RoleId { get; set; }


		public string ControllerNameForTitle { get; set; }

		public List<RoleListVM> Roles { get; set; }
	}
}
