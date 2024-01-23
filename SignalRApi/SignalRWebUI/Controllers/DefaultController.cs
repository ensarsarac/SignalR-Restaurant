using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.MessageDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class DefaultController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult OurMenu()
		{
			return View();
		}

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Booking()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> SendMessage(CreateMessageDto model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7037/api/Message", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}



	}
}
