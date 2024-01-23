using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class AdminStatisticController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
