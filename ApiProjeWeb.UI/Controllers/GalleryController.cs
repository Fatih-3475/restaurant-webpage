using ApiProjeWeb.UI.Dtos.ImageDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ApiProjeWeb.UI.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GalleryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ImageList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7118/api/Images");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultImageDto>>(jsonData);
                return View(values);
            }

            return View(new List<ResultImageDto>());
        }

        [HttpGet]
        public IActionResult CreateImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(CreateImageDto createImageDto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                using var content = new MultipartFormDataContent();

                if (!string.IsNullOrWhiteSpace(createImageDto.Title))
                {
                    content.Add(new StringContent(createImageDto.Title), "Title");
                }

                if (createImageDto.Photo != null && createImageDto.Photo.Length > 0)
                {
                    var streamContent = new StreamContent(createImageDto.Photo.OpenReadStream());

                    if (!string.IsNullOrWhiteSpace(createImageDto.Photo.ContentType))
                    {
                        streamContent.Headers.ContentType =
                            new MediaTypeHeaderValue(createImageDto.Photo.ContentType);
                    }

                    content.Add(streamContent, "Photo", createImageDto.Photo.FileName);
                }

                var responseMessage = await client.PostAsync("https://localhost:7118/api/Images", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ImageList");
                }

                ViewBag.ErrorMessage = await responseMessage.Content.ReadAsStringAsync();
                return View(createImageDto);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(createImageDto);
            }
        }

        public async Task<IActionResult> DeleteImage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7118/api/Images/{id}");
            return RedirectToAction("ImageList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateImage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7118/api/Images/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateImageDto>(jsonData);
                return View(value);
            }

            return RedirectToAction("ImageList");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateImage(UpdateImageDto updateImageDto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                using var content = new MultipartFormDataContent();
                content.Add(new StringContent(updateImageDto.ImageId.ToString()), "ImageId");

                if (!string.IsNullOrWhiteSpace(updateImageDto.Title))
                {
                    content.Add(new StringContent(updateImageDto.Title), "Title");
                }

                if (!string.IsNullOrWhiteSpace(updateImageDto.ImageUrl))
                {
                    content.Add(new StringContent(updateImageDto.ImageUrl), "ImageUrl");
                }

                if (updateImageDto.Photo != null && updateImageDto.Photo.Length > 0)
                {
                    var streamContent = new StreamContent(updateImageDto.Photo.OpenReadStream());

                    if (!string.IsNullOrWhiteSpace(updateImageDto.Photo.ContentType))
                    {
                        streamContent.Headers.ContentType =
                            new MediaTypeHeaderValue(updateImageDto.Photo.ContentType);
                    }

                    content.Add(streamContent, "Photo", updateImageDto.Photo.FileName);
                }

                var request = new HttpRequestMessage(HttpMethod.Put, "https://localhost:7118/api/Images")
                {
                    Content = content
                };

                var responseMessage = await client.SendAsync(request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ImageList");
                }

                ViewBag.ErrorMessage = await responseMessage.Content.ReadAsStringAsync();
                return View(updateImageDto);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(updateImageDto);
            }
        }
    }
}