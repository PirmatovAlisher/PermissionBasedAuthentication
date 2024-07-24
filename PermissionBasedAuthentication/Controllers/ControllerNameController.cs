using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermissionBasedAuthentication.Models.ViewModels.ControllerVM;
using PermissionBasedAuthentication.Services.ControllerNameService;

namespace PermissionBasedAuthentication.Controllers
{
	public class ControllerNameController : Controller
	{
		private readonly IControllerNameService _controllerNameService;
		private readonly IMapper _mapper;

		public ControllerNameController(IControllerNameService controllerNameService, IMapper mapper)
		{
			_controllerNameService = controllerNameService;
			_mapper = mapper;
		}

		public IActionResult GetAllControllerList()
		{
			var controllerList = _controllerNameService.GetAllItems().ToList();

			var mappedControllerList = _mapper.Map<List<ControllerListVM>>(controllerList);
			return View(mappedControllerList);
		}

		public IActionResult RefreshList()
		{
			_controllerNameService.RefreshControllers();
			return RedirectToAction("GetAllControllerList", "ControllerName");
		}
	}
}
