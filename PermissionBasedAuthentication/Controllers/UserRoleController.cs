using Microsoft.AspNetCore.Mvc;

namespace PermissionBasedAuthentication.Controllers
{
	public class UserRoleController : Controller
	{
		public IActionResult GetUserRoles()
		{
			return View();
		}

		public IActionResult AddRoleToUser()
		{
			return View();
		}

		public IActionResult RemoveRoleFromUser()
		{
			return View();
		}
	}
}
