using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PermissionBasedAuthentication.Controllers
{
	[Authorize]
	public class RoleController : Controller
	{
		// CRUD operations
	}
}
