using Microsoft.AspNetCore.Mvc;

namespace PermissionBasedAuthentication.DynamicAuth
{
	public class DynamicAuthorizationAttribute : TypeFilterAttribute
	{
		public DynamicAuthorizationAttribute() : base(typeof(DynamicAuthorizationFilter))
		{
		}
	}
}
