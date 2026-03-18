using ApiProjeWeb.UI.Dtos.ChefDtos;
using ApiProjeWeb.UI.Dtos.MessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeWeb.UI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarMessageListAdminLayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavbarMessageListAdminLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessega = await client.GetAsync("https://localhost:7118/api/Messeges/MessageListByIsReadFalse");

            if (responseMessega.IsSuccessStatusCode)
            {
                var jsonData = await responseMessega.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageByIsReadFalseDto>>(jsonData);
                return View(values);
            }

            return View(new List<ResultMessageByIsReadFalseDto>());
        }
    }
}
