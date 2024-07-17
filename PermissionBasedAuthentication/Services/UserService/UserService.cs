using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using PermissionBasedAuthentication.GenericRepositories;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.UserVM;
using System.Security.Claims;

namespace PermissionBasedAuthentication.Services.UserService
{
	public class UserService : GenericService<User>, IUserService
	{
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly IMapper _mapper;

		public UserService(IGenericRepository<User> repository, IMapper mapper, IHttpContextAccessor contextAccessor) : base(repository)
		{
			_mapper = mapper;
			_contextAccessor = contextAccessor;
		}


		public void CreateEntity(UserCreateVM request)
		{
			bool passwordCheck = request.Password.Equals(request.ConfirmPassword);
			if (!passwordCheck)
			{
				//Exception
				return;
			}

			var user = _mapper.Map<User>(request);
			user.PasswordHash = HashMaker(user, request.Password);

			_repository.CreateItem(user);

		}

		public bool SignIn(string email, string providedPassword)
		{
			var user = _repository.GetAll().Where(x => x.Email.Equals(email)).FirstOrDefault();
			if (user == null)
			{
				return false;
			}

			var passwordVerify = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, providedPassword);
			if (passwordVerify == PasswordVerificationResult.Failed)
			{
				return false;
			}


			var claims = new List<Claim>
			{
				new(ClaimTypes.Email, user.Email),
				new(ClaimTypes.Name, user.FullName),
				new(ClaimTypes.NameIdentifier, user.Id.ToString())
			};

			// Add roles

			var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			_contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

			return true;

		}

		private string HashMaker(User user, string password)
		{
			var hashedPassword = new PasswordHasher<User>().HashPassword(user, password);
			return hashedPassword;
		}
	}
}
