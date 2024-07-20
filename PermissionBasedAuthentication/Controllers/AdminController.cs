using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermissionBasedAuthentication.GenericRepositories;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.UserVM;
using PermissionBasedAuthentication.Services;

namespace PermissionBasedAuthentication.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		private readonly IGenericService<User> _userService;
		private readonly IMapper _mapper;

		public AdminController(IGenericService<User> userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		public IActionResult UserList()
		{
			var userList = _userService.GetAllItems().ToList();
			var mappedUserList = _mapper.Map<List<UserListVM>>(userList);

			return View(mappedUserList);
		}

		public IActionResult RemoveUser(int Id)
		{
			_userService.DeleteEntity(Id);
			return RedirectToAction("UserList", "Admin");
		}
	}
}
