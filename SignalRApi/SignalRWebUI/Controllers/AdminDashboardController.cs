using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class AdminDashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
