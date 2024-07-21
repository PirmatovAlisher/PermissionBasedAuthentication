using AutoMapper;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.UserRoleVM;

namespace PermissionBasedAuthentication.Mapper
{
	public class UserRoleMapper : Profile
	{
        public UserRoleMapper()
        {
            CreateMap<UserRole, UserRoleCreateVM>().ReverseMap();
            CreateMap<UserRole, UserRoleUpdateVM>().ReverseMap();
            CreateMap<UserRole, UserRoleListVM>().ReverseMap();
        }
    }
}
