using Microsoft.AspNetCore.Mvc;

namespace PermissionBasedAuthentication.Controllers
{
	public class AuthenticatedController : Controller
	{
		public IActionResult EditUser()
		{
			return View();
		}

		public IActionResult Logout()
		{
			return View();
		}
	}
}
