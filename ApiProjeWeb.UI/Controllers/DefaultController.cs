using ApiProjeWeb.UI.Dtos.ImageDto;
using ApiProjeWeb.UI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeWeb.UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var serviceResponse = await client.GetAsync("https://localhost:7118/api/Services");
            List<ResultServiceDto> services = new List<ResultServiceDto>();

            if (serviceResponse.IsSuccessStatusCode)
            {
                var serviceJson = await serviceResponse.Content.ReadAsStringAsync();
                services = JsonConvert.DeserializeObject<List<ResultServiceDto>>(serviceJson);
            }

            var imageResponse = await client.GetAsync("https://localhost:7118/api/Images");
            List<ResultImageDto> images = new List<ResultImageDto>();

            if (imageResponse.IsSuccessStatusCode)
            {
                var imageJson = await imageResponse.Content.ReadAsStringAsync();
                images = JsonConvert.DeserializeObject<List<ResultImageDto>>(imageJson);
            }

            ViewBag.Images = images;

            return View(services);
        }
    }
}