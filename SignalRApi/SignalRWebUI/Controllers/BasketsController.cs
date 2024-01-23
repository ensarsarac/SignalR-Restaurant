using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDataAccessLayer.Concrete;
using SignalREntityLayer.Entities;
using SignalRWebUI.Dtos.BasketDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BasketsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;
		public BasketsController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
		{
			_httpClientFactory = httpClientFactory;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
        {
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7037/api/Basket?id={user.Id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultBasketDto>>(readData);
                return View(jsonData);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddBasket(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            using var context = new SignalRContext();
            var productPrice = context.Products.Where(x => x.ProductID == id).Select(y => y.Price).FirstOrDefault();
            CreateBasketDto model = new CreateBasketDto()
            {
                Count = 1,
                Price = productPrice,
                MenuTableID = 4,
                ProductID = id,
                TotalPrice = 1 * productPrice,
                AppUserID = user.Id,
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            await client.PostAsync("https://localhost:7037/api/Basket",content);
            return Json(id);
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7037/api/Basket/{id}");
			return Json(id);			
        }

    }
}
