using Microsoft.AspNetCore.Mvc;
using PermissionBasedAuthentication.GenericRepositories;
using PermissionBasedAuthentication.Models.Entity;
using System.Reflection;

namespace PermissionBasedAuthentication.Services.ControllerNameService
{
	public class ControllerNameService : GenericService<ControllerName>, IControllerNameService
	{
		public ControllerNameService(IGenericRepository<ControllerName> repository) : base(repository)
		{
		}

		public void RefreshControllers()
		{
			var controllerListOnProject = Assembly.GetExecutingAssembly()
												  .GetTypes()
												  .Where(type =>
												  typeof(Controller).IsAssignableFrom(type) ||
												  typeof(ControllerBase).IsAssignableFrom(type))
												  .ToDictionary(x => x.Name.Substring(0, x.Name.LastIndexOf("Controller")));

			var controllerListOnDb = _repository.GetAll().ToList();

			foreach (var controller in controllerListOnDb)
			{
				if (!controllerListOnProject.TryGetValue(controller.Name, out var type))
				{
					_repository.DeleteItem(controller);
				}
			}

			var controllerNewListOnDb = _repository.GetAll().ToList();

			foreach (var controllerName in controllerListOnProject)
			{
				if (controllerNewListOnDb.Any(x => x.Name.Equals(controllerName.Key)))
				{
					continue;
				}

				_repository.CreateItem(new ControllerName
				{
					Name = controllerName.Key,
				});
			}
		}
	}
}
