using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PermissionBasedAuthentication.GenericRepositories;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Models.ViewModels.UserVM;

namespace PermissionBasedAuthentication.Services.UserService
{
	public class UserService : GenericService<User>, IUserService
	{
		private readonly IMapper _mapper;

		public UserService(IGenericRepository<User> repository, IMapper mapper) : base(repository)
		{
			_mapper = mapper;
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

		private string HashMaker(User user, string password)
		{
			var hashedPassword = new PasswordHasher<User>().HashPassword(user, password);
			return hashedPassword;
		}
	}
}
