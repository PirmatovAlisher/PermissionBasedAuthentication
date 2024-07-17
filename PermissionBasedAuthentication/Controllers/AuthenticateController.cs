using Microsoft.AspNetCore.Mvc;
using PermissionBasedAuthentication.Models.Others;
using PermissionBasedAuthentication.Models.ViewModels.UserVM;
using PermissionBasedAuthentication.Services;
using PermissionBasedAuthentication.Services.UserService;

namespace PermissionBasedAuthentication.Controllers
{
	public class AuthenticateController : Controller
	{
		private readonly IUserService _userService;

		public AuthenticateController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public IActionResult Register()
		{

			return View();
		}

		[HttpPost]
		public IActionResult Register(UserCreateVM request)
		{
			_userService.CreateEntity(request);

			return RedirectToAction("Login", "Authenticate");
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Login(LoginVM request)
		{
			var result = _userService.SignIn(request.Email, request.Password);
			if (!result)
			{
				ViewBag.Error = "User name or password is incorrect";
				return View(request);
			}

			return RedirectToAction("Index", "Dashboard");
		}
	}
}
