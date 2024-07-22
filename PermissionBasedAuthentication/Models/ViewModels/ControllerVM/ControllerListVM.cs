using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.DomainVM;

namespace PermissionBasedAuthentication.Models.ViewModels.ControllerVM
{
	public class ControllerListVM
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public List<DomainListVM> DomainList { get; set; }
	}
}
