﻿namespace PermissionBasedAuthentication.Models.ViewModels.DomainVM
{
	public class DomainListWithParamsVM
	{
		public List<DomainListVM> DomainList { get; set; }

		public ControllerParamsVM ControllerParams { get; set; }
	}
}
