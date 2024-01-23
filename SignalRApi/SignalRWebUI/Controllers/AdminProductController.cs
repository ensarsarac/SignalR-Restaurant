using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Runtime.InteropServices;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class AdminProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7037/api/Product/ProductListWithCategory");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<List<ResultProductDto>>(readData);
				return View(jsonData);
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CreateProduct()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7037/api/Category");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<List<CreateProductForCategory>>(readData);
				//IEnumerable<SelectListItem> values = (from x in jsonData
				//									  select new SelectListItem
				//									  {
				//										  Text = x.Name,
				//										  Value = x.CategoryID.ToString(),
				//									  }).ToList();
				//ViewBag.categories = values;
				ViewBag.categories = new SelectList(jsonData, "CategoryID", "Name");
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto model)
		{
			model.ImageUrl = "image";
			model.ProductStatus = false;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7037/api/Product",content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7037/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateProduct(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7037/api/Product/GetProductWithId?id={id}");
			var responseMessage2 = await client.GetAsync("https://localhost:7037/api/Category");


			if (responseMessage.IsSuccessStatusCode)
			{
				var readData2 = await responseMessage2.Content.ReadAsStringAsync();
				var jsonData2 = JsonConvert.DeserializeObject<List<CreateProductForCategory>>(readData2);
				ViewBag.categories = new SelectList(jsonData2, "CategoryID", "Name");
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<UpdateProductDto>(readData);
				return View(jsonData);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent content= new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("https://localhost:7037/api/Product", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				
				return RedirectToAction("Index");
			}
			return View();
		}




	}
}
