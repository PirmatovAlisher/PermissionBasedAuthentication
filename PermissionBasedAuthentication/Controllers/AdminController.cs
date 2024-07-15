using Microsoft.AspNetCore.Mvc;

namespace PermissionBasedAuthentication.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult UserList()
		{
			return View();
		}

		public IActionResult RemoveUser()
		{
			return View();
		}
	}
}
