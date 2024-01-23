using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class AdminAboutController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		
		public AdminAboutController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7037/api/About");
			if(responseMessage.IsSuccessStatusCode) {

				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<ResultAboutDto>(readData);
				return View(jsonData);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateAbout(ResultAboutDto model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync($"https://localhost:7037/api/About",content);
			if (responseMessage.IsSuccessStatusCode)
			{				
				return RedirectToAction("Index");
			}
			return View();
		}




	}
}
