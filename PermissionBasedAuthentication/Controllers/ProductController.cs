using Microsoft.AspNetCore.Mvc;
using PermissionBasedAuthentication.Models.Entity;
using PermissionBasedAuthentication.Services;

namespace PermissionBasedAuthentication.Controllers
{
	public class ProductController : Controller
	{
		private readonly IGenericService<Product> _service;
		private readonly IGenericService<Category> _categoryService;


		public ProductController(IGenericService<Product> service, IGenericService<Category> categoryService)
		{
			_service = service;
			_categoryService = categoryService;
		}

		public IActionResult GetAllProducts()
		{
			var products = _service.GetAllItems(x => x.Category);
			return View(products);
		}

		[HttpGet]
		public IActionResult CreateProduct()
		{
			var categories = _categoryService.GetAllItems();
			ViewBag.Categories = categories;
			return View();
		}

		[HttpPost]
		public IActionResult CreateProduct(Product request)
		{
			_service.CreateEntity(request);
			return RedirectToAction("GetAllProducts", "Product");
		}
		[HttpGet]
		public IActionResult UpdateProduct(int id)
		{
			var categories = _categoryService.GetAllItems();
			ViewBag.Categories = categories;

			var product = _service.GetEntityById(id);
			return View(product);
		}

		[HttpPost]
		public IActionResult UpdateProduct(Product request)
		{
			_service.UpdateEntity(request);
			return RedirectToAction("GetAllProducts", "Product");
		}

		public IActionResult DeleteProduct(int id)
		{
			_service.DeleteEntity(id);
			return RedirectToAction("GetAllProducts", "Product");
		}

	}
}
