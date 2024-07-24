using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.DomainVM;
using PermissionBasedAuthentication.Models.ViewModels.RoleVM;
using PermissionBasedAuthentication.Services;
using PermissionBasedAuthentication.Services.DomainService;

namespace PermissionBasedAuthentication.Controllers
{
	public class DomainController : Controller
	{
		private readonly IDomainService _domainService;
		private readonly IGenericService<Role> _roleService;
		private readonly IMapper _mapper;

		public DomainController(IDomainService domainService, IGenericService<Role> roleService, IMapper mapper)
		{
			_domainService = domainService;
			_roleService = roleService;
			_mapper = mapper;
		}

		public IActionResult GetAllListByRole(int roleId)
		{
			var doaminList = _domainService.GetAllDomainsByRoleId(roleId);
			return View(doaminList);
		}

		public IActionResult GetAllDomainsByControllerNameId(ControllerParamsVM model)
		{
			var domainListWithRoles = _domainService.GetAllDomainsByControllerNameId(model.ControllerId);
			return View(new DomainListWithParamsVM { DomainList = domainListWithRoles, ControllerParams = model });
		}

		[HttpGet]
		public IActionResult AddDomainRoleToController(ControllerParamsVM model)
		{
			var roleList = _roleService.GetAllItems().ToList();
			var mappedRoleList = _mapper.Map<List<RoleListVM>>(roleList);

			return View(new DomainCreateVM
			{
				Roles = mappedRoleList,
				ControllerNameId = model.ControllerId,
				ControllerNameForTitle = model.ControllerName
			});
		}


		[HttpPost]
		public IActionResult AddDomainRoleToController(DomainCreateVM request)
		{
			var mappedRequest = _mapper.Map<Domain>(request);
			_domainService.CreateEntity(mappedRequest);

			return RedirectToAction("GetAllDomainsByControllerNameId", "Domain", new
			{
				controllerId = request.ControllerNameId,
				controllerName = request.ControllerNameForTitle
			});
		}

		[HttpGet]
		public IActionResult UpdateDomainRoleForController(ControllerParamsVM model)
		{
			var domainRole = _domainService.GetItemByModal(model);
			var roleList = _roleService.GetAllItems().ToList();
			var mappedRoleList = _mapper.Map<List<RoleListVM>>(roleList);

			domainRole.Roles = mappedRoleList;

			return View(domainRole);
		}


		[HttpPost]
		public IActionResult UpdateDomainRoleForController(DomainUpdateVM request)
		{
			var mappedDomain = _mapper.Map<Domain>(request);

			_domainService.UpdateEntity(mappedDomain);

			return RedirectToAction("GetAllDomainsByControllerNameId", "Domain", new
			{
				controllerId = request.ControllerNameId,
				controllerName = request.ControllerNameForTitle
			});
		}

		public IActionResult RemoveDomainRoleFromController(ControllerParamsVM model)
		{
			_domainService.DeleteEntity(model.Id);

			return RedirectToAction("GetAllDomainsByControllerNameId", "Domain", new
			{
				controllerId = model.ControllerId,
				controllerName = model.ControllerName
			});
		}
	}
}
