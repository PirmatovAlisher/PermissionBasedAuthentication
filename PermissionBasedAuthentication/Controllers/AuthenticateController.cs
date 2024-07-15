using Microsoft.AspNetCore.Mvc;

namespace PermissionBasedAuthentication.Controllers
{
	public class AuthenticateController : Controller
	{
		public IActionResult Register()
		{
			return View();
		}


		public IActionResult Login()
		{
			return View();
		}
	}
}
