using AutoMapper;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.ControllerVM;

namespace PermissionBasedAuthentication.Mapper
{
	public class ControllerNameMapper : Profile
	{
        public ControllerNameMapper()
        {
            CreateMap<ControllerName, ControllerListVM>().ReverseMap();
            CreateMap<ControllerName, ControllerCreateVM>().ReverseMap();
            CreateMap<ControllerName, ControllerUpdateVM>().ReverseMap();
        }
    }
}
