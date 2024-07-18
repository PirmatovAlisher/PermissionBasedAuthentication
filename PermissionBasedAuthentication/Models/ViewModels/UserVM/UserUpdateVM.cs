namespace PermissionBasedAuthentication.Models.ViewModels.UserVM
{
	public class UserUpdateVM
	{
		public int Id { get; set; }	

		public string FullName { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public string? NewPassword { get; set; }

		public string? NewPasswordConfirm { get; set; }
	}
}
