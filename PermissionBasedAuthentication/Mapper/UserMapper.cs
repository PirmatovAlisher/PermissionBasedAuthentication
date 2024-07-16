using AutoMapper;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.UserVM;

namespace PermissionBasedAuthentication.Mapper
{
	public class UserMapper : Profile
	{
		public UserMapper()
		{
			CreateMap<User, UserCreateVM>().ReverseMap();
			CreateMap<User, UserUpdateVM>().ReverseMap();
			CreateMap<User, UserListVM>().ReverseMap();
		}
	}
}
