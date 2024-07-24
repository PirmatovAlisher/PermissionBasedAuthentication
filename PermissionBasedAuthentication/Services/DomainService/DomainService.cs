using AutoMapper;
using PermissionBasedAuthentication.GenericRepositories;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.DomainVM;

namespace PermissionBasedAuthentication.Services.DomainService
{
	public class DomainService : GenericService<Domain>, IDomainService
	{
		private readonly IMapper _mapper;

		public DomainService(IGenericRepository<Domain> repository, IMapper mapper) : base(repository)
		{
			_mapper = mapper;
		}

		public List<DomainListVM> GetAllDomainsByRoleId(int roleId)
		{
			var domainList = GetAllItems().Where(x => x.RoleId == roleId).ToList();
			var mappedDomainList = _mapper.Map<List<DomainListVM>>(domainList);

			return mappedDomainList;
		}

		public List<DomainListVM> GetAllDomainsByControllerNameId(int controllerId)
		{
			var domainListWithRoles = GetAllItems().Where(x => x.ControllerNameId == controllerId).ToList();

			var mappedDomainListWithRoles = _mapper.Map<List<DomainListVM>>(domainListWithRoles);
			return mappedDomainListWithRoles;
		}

		public DomainUpdateVM GetItemByModal(ControllerParamsVM model)
		{
			var domainRole = GetEntityById(model.Id);
			var mappedDomainRole = _mapper.Map<DomainUpdateVM>(domainRole);

			mappedDomainRole.ControllerNameId = model.ControllerId;
			mappedDomainRole.ControllerNameForTitle = model.ControllerName;
			return mappedDomainRole;
		}
	}
}
