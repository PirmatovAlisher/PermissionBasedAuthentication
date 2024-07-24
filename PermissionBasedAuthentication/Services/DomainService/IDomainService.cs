using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.DomainVM;

namespace PermissionBasedAuthentication.Services.DomainService
{
	public interface IDomainService : IGenericService<Domain>
	{
		List<DomainListVM> GetAllDomainsByRoleId(int roleId);
		List<DomainListVM> GetAllDomainsByControllerNameId(int controllerId);
		DomainUpdateVM GetItemByModal(ControllerParamsVM model);
		List<DomainListVM> GetAllDomainsByControllerName(string controllerName);
	}
}
