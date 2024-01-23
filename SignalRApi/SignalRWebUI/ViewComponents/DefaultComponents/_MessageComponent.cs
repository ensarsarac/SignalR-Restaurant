using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
	public class _MessageComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public IViewComponentResult Invoke()
		{		
			return View();
		}
	}
}
