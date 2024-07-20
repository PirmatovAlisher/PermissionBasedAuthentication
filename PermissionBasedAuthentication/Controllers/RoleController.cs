using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.RoleVM;
using PermissionBasedAuthentication.Services;

namespace PermissionBasedAuthentication.Controllers
{
	[Authorize]
	public class RoleController : Controller
	{
		private readonly IGenericService<Role> _roleService;
		private readonly IMapper _mapper;

		public RoleController(IGenericService<Role> roleService, IMapper mapper)
		{
			_roleService = roleService;
			_mapper = mapper;
		}

		public IActionResult GetAllRoles()
		{
			var roles = _roleService.GetAllItems().ToList();
			var mappedRoles = _mapper.Map<List<RoleListVM>>(roles);

			return View(mappedRoles);
		}

		[HttpGet]
		public IActionResult CreateRole()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateRole(RoleCreateVM request)
		{
			var roleMapped = _mapper.Map<Role>(request);
			_roleService.CreateEntity(roleMapped);

			return RedirectToAction("GetAllRoles", "Role");
		}

		[HttpGet]
		public IActionResult UpdateRole(int Id)
		{
			var role = _roleService.GetEntityById(Id);
			var roleMapped = _mapper.Map<RoleUpdateVM>(role);

			return View(roleMapped);
		}

		[HttpPost]
		public IActionResult UpdateRole(RoleUpdateVM request)
		{
			var roleMapped = _mapper.Map<Role>(request);
			_roleService.UpdateEntity(roleMapped);

			return RedirectToAction("GetAllRoles", "Role");
		}

		public IActionResult DeleteRole(int Id)
		{
			_roleService.DeleteEntity(Id);
			return RedirectToAction("GetAllRoles", "Role");
		}

	}
}
