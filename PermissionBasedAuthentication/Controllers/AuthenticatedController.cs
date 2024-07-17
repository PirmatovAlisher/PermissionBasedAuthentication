using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PermissionBasedAuthentication.Controllers
{
	public class AuthenticatedController : Controller
	{
		[Authorize]
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
