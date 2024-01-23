using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class FooterComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FooterComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7037/api/Contact");
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<ResultContactDto>(readData);

            return View(jsonData);
        }
    }
}
