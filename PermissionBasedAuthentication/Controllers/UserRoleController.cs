using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.RoleVM;
using PermissionBasedAuthentication.Models.ViewModels.UserRoleVM;
using PermissionBasedAuthentication.Services;

namespace PermissionBasedAuthentication.Controllers
{
	[Authorize]
	public class UserRoleController : Controller
	{
		private readonly IGenericService<UserRole> _userRoleService;
		private readonly IGenericService<Role> _roleService;
		private readonly IGenericService<User> _userService;
		private readonly IMapper _mapper;

		public UserRoleController(IMapper mapper, IGenericService<UserRole> userRoleService, IGenericService<Role> roleService, IGenericService<User> userService)
		{
			_userRoleService = userRoleService;
			_roleService = roleService;
			_mapper = mapper;
			_userService = userService;
		}

		public IActionResult GetUserRoles(int userId)
		{
			var allRoles = _roleService.GetAllItems();
			var user = _userService.GetAllItems().FirstOrDefault(x => x.Id == userId);

			var availableRoles = new List<Role>();
			foreach (var role in allRoles)
			{
				if (!user.UserRoles.Any(x => x.RoleId == role.Id))
				{

					availableRoles.Add(role);
				}
			}

			var mappedAvailableRoles = _mapper.Map<List<RoleListVM>>(availableRoles);
			ViewBag.Roles = mappedAvailableRoles;

			var userRoles = _userRoleService.GetAllItems().Where(x => x.User.Id == userId).ToList();
			var mappedUserRoles = _mapper.Map<List<UserRoleListVM>>(userRoles);

			return View(mappedUserRoles);
		}

		[HttpPost]
		public IActionResult AddRoleToUser(UserRoleCreateVM request)
		{

			var mappedUserRole = _mapper.Map<UserRole>(request);
			_userRoleService.CreateEntity(mappedUserRole);

			return RedirectToAction("GetUserRoles", "UserRole", new { userId = request.UserId });
		}

		public IActionResult RemoveRoleFromUser(int id, int userId)
		{
			var user = _userService.GetAllItems().FirstOrDefault(x => x.Id == userId);
			if (user.UserRoles.Count is 1)
			{
				throw new Exception("User must have at least one Role");
			}
			_userRoleService.DeleteEntity(id);

			return RedirectToAction("GetUserRoles", "UserRole", new { userId });
		}
	}
}
