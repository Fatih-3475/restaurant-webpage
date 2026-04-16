using ApiProjeWeb.UI.Dtos.CategoryDtos;
using ApiProjeWeb.UI.Dtos.MessageDtos;
using ApiProjeWeb.UI.Dtos.ProductDtos;
using ApiProjeWeb.UI.Dtos.ReservationDto;
using ApiProjeWeb.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeWeb.UI.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminLayoutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var model = new AdminDashboardViewModel();
            var client = _httpClientFactory.CreateClient();

            // Kategoriler
            var categoryResponse = await client.GetAsync("https://localhost:7118/api/Categories");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var jsonData = await categoryResponse.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData) ?? new();
                model.CategoryCount = categories.Count;
            }

            // Ürünler
            var productResponse = await client.GetAsync("https://localhost:7118/api/Products/ProductListWithCategory");
            List<ResultProductDto> products = new();
            if (productResponse.IsSuccessStatusCode)
            {
                var jsonData = await productResponse.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData) ?? new();

                model.ProductCount = products.Count;

                if (products.Any())
                {
                    model.AverageProductPrice = products.Average(x => x.Price);

                    var maxProduct = products.OrderByDescending(x => x.Price).FirstOrDefault();
                    if (maxProduct != null)
                    {
                        model.MostExpensiveProductName = maxProduct.ProductName ?? "";
                        model.MostExpensiveProductPrice = maxProduct.Price;
                    }

                    var minProduct = products.OrderBy(x => x.Price).FirstOrDefault();
                    if (minProduct != null)
                    {
                        model.CheapestProductName = minProduct.ProductName ?? "";
                        model.CheapestProductPrice = minProduct.Price;
                    }

                    model.ProductCountByCategory = products
                        .Where(x => !string.IsNullOrEmpty(x.CategoryName))
                        .GroupBy(x => x.CategoryName!)
                        .ToDictionary(g => g.Key, g => g.Count());
                }
            }

            // Rezervasyonlar
            var reservationResponse = await client.GetAsync("https://localhost:7118/api/Reservations");
            List<ResultReservationDto> reservations = new();
            if (reservationResponse.IsSuccessStatusCode)
            {
                var jsonData = await reservationResponse.Content.ReadAsStringAsync();
                reservations = JsonConvert.DeserializeObject<List<ResultReservationDto>>(jsonData) ?? new();

                model.ReservationCount = reservations.Count;
                model.LastReservations = reservations
                    .OrderByDescending(x => x.ReservationDate)
                    .Take(5)
                    .ToList();
            }

            // Mesajlar
            var messageResponse = await client.GetAsync("https://localhost:7118/api/Messeges");
            if (messageResponse.IsSuccessStatusCode)
            {
                var jsonData = await messageResponse.Content.ReadAsStringAsync();
                var messages = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData) ?? new();

                model.UnreadMessageCount = messages.Count(x => x.IsRead == false);
                model.LastMessages = messages
                    .OrderByDescending(x => x.SendData)
                    .Take(5)
                    .ToList();
            }

            return View(model);
        }
    }
}