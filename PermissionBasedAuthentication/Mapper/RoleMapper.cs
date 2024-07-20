using AutoMapper;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.RoleVM;

namespace PermissionBasedAuthentication.Mapper
{
	public class RoleMapper : Profile
	{
		public RoleMapper()
		{
			CreateMap<Role, RoleCreateVM>().ReverseMap();
			CreateMap<Role, RoleUpdateVM>().ReverseMap();
			CreateMap<Role, RoleListVM>().ReverseMap();
		}
	}
}
