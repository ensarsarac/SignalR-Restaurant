using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _AboutComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7037/api/About");
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<ResultAboutDto>(readData);

            return View(jsonData);
        }
    }
}
