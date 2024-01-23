using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMediaDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _SocialMediaComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _SocialMediaComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7037/api/SocialMedia");
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(readData);

            return View(jsonData);
        }
    }
}
