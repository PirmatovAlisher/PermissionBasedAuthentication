using PermissionBasedAuthentication.GenericRepositories;
using PermissionBasedAuthentication.Models.Entity;

namespace PermissionBasedAuthentication.Services.DomainService
{
	public class DomainService : GenericService<Domain>, IDomainService
	{
		public DomainService(IGenericRepository<Domain> repository) : base(repository)
		{
		}
	}
}
