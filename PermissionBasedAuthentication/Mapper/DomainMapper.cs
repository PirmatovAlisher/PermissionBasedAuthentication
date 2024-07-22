using AutoMapper;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.DomainVM;

namespace PermissionBasedAuthentication.Mapper
{
	public class DomainMapper : Profile
	{
        public DomainMapper()
        {
            CreateMap<Domain, DomainListVM>().ReverseMap();
            CreateMap<Domain, DomainCreateVM>().ReverseMap();
            CreateMap<Domain, DomainUpdateVM>().ReverseMap();
        }
    }
}
