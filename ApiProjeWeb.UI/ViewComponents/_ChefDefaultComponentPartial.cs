using ApiProjeWeb.UI.Dtos.ChefDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeWeb.UI.ViewComponents
{
    public class _ChefDefaultComponentPartial:ViewComponent
    {
            private readonly IHttpClientFactory _httpClientFactory;

            public _ChefDefaultComponentPartial(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            public async Task<IViewComponentResult> InvokeAsync()
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessega = await client.GetAsync("https://localhost:7118/api/Chefs/");

                if (responseMessega.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessega.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultChefDto>>(jsonData);
                    return View(values);
                }

                return View(new List<ResultChefDto>());
            }
        }

}
