using ApiProjeWeb.UI.Dtos.ReservationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeWeb.UI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ReservationList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7118/api/Reservations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReservationDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultReservationDto>());
        }

        [HttpGet]
        public IActionResult CreateReservation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7118/api/Reservations", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ReservationList");
            }

            return View(createReservationDto);
        }

        public async Task<IActionResult> DeleteReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7118/api/Reservations/" + id);
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7118/api/Reservations/" + id);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ReservationList");
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateReservationDto>(jsonData);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7118/api/Reservations", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ReservationList");
            }

            return View(updateReservationDto);
        }
    }
}
