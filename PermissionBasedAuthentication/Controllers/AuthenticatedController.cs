using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermissionBasedAuthentication.Models.ViewModels.UserVM;
using PermissionBasedAuthentication.Services.UserService;

namespace PermissionBasedAuthentication.Controllers
{
	[Authorize(Roles = "Member, Admin")]
	public class AuthenticatedController : Controller
	{
		private readonly IUserService _userService;
		private readonly IMapper _mapper;

		public AuthenticatedController(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		[Authorize]
		[HttpGet]
		public IActionResult EditUser(int id)
		{
			var user = _userService.GetEntityById(id);
			var mappedUser = _mapper.Map<UserUpdateVM>(user);
			return View(mappedUser);
		}
		[Authorize]
		[HttpPost]
		public IActionResult EditUser(UserUpdateVM request)
		{
			_userService.UpdateEntity(request);
			return RedirectToAction("Login", "Authenticate");
		}

		public IActionResult Logout()
		{
			_userService.SignOut();
			return RedirectToAction("Login", "Authenticate");
		}
	}
}
