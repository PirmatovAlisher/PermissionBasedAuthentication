using Microsoft.AspNetCore.Mvc;

namespace PermissionBasedAuthentication.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
