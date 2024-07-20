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
		private readonly IGenericRepository<Role> _roleRepository;
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly IMapper _mapper;

		public UserService(IGenericRepository<User> repository, IMapper mapper, IHttpContextAccessor contextAccessor, IGenericRepository<Role> roleRepository) : base(repository)
		{
			_mapper = mapper;
			_contextAccessor = contextAccessor;
			_roleRepository = roleRepository;
		}


		public void CreateEntity(UserCreateVM request)
		{
			bool passwordCheck = request.Password.Equals(request.ConfirmPassword);
			if (!passwordCheck)
			{
				throw new Exception("Password does not match with Confirm password");
			}

			var user = _mapper.Map<User>(request);
			user.PasswordHash = HashMaker(user, request.Password);

			var memberRole = _roleRepository.GetAll().FirstOrDefault(x => x.RoleName.Equals("Member"));
			if (memberRole == null)
			{
				throw new Exception("Role does not exist, contact with Admin");
			}

			var userRole = new UserRole()
			{
				RoleId = memberRole.Id,
				UserId = user.Id
			};

			if (!user.UserRoles.Any())
			{
				user.UserRoles = new List<UserRole>();
			}

			user.UserRoles.Add(userRole);

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
			foreach (var userRole in user.UserRoles)
			{
				var roleClaim = new Claim(ClaimTypes.Role, userRole.Role.RoleName);
				claims.Add(roleClaim);
			}

			var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			_contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

			return true;

		}

		public void SignOut()
		{
			_contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
		}

		public void UpdateEntity(UserUpdateVM request)
		{
			var user = _repository.GetAll().Where(x => x.Email.Equals(request.Email)).FirstOrDefault();
			if (user == null)
			{
				throw new Exception("Email or Password is wrong");
			}

			var verifyPassword = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password);

			if (verifyPassword == PasswordVerificationResult.Failed)
			{
				throw new Exception("Email or Password is wrong");
			}

			var mappedUser = _mapper.Map<User>(request);

			if (string.IsNullOrWhiteSpace(request.NewPassword))
			{
				mappedUser.PasswordHash = user.PasswordHash;
				_repository.UpdateItem(mappedUser);
				return;
			}

			if (!request.NewPassword.Equals(request.NewPasswordConfirm))
			{
				throw new Exception("New password does not match with Confirm password");
			}

			var newPasswordHash = HashMaker(user, request.NewPassword);

			mappedUser.PasswordHash = newPasswordHash;

			_repository.UpdateItem(mappedUser);

		}

		private string HashMaker(User user, string password)
		{
			var hashedPassword = new PasswordHasher<User>().HashPassword(user, password);
			return hashedPassword;
		}
	}
}
