using Microsoft.AspNetCore.Mvc;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Services;

namespace PermissionBasedAuthentication.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IGenericService<Category> _service;

		public CategoryController(IGenericService<Category> service)
		{
			_service = service;
		}

		public IActionResult GetAllCategories()
		{
			var categories = _service.GetAllItems();

			return View(categories);
		}

		[HttpGet]
		public IActionResult CreateCategory()
		{
			return View();
		}


		[HttpPost]
		public IActionResult CreateCategory(Category request)
		{
			_service.CreateEntity(request);
			return RedirectToAction("GetAllCategories", "Category");
		}

		[HttpGet]
		public IActionResult UpdateCategory(int id)
		{
			var category = _service.GetEntityById(id);
			return View(category);
		}

		[HttpPost]
		public IActionResult UpdateCategory(Category category)
		{
			_service.UpdateEntity(category);
			return RedirectToAction("GetAllCategories", "Category");
		}

		public IActionResult DeleteCategory(int id)
		{
			_service.DeleteEntity(id);
			return RedirectToAction("GetAllCategories", "Category");
		}
	}
}
