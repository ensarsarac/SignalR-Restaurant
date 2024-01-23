using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class BookATableController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookATableController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult CreateBook()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateBook(CreateBookingDto model)
		{
			model.Status = "Rezervasyon Alındı";
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:7037/api/Booking",content);
			if(responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Booking", "Default");
			}
			return RedirectToAction("Booking", "Default");
		}
	}
}
