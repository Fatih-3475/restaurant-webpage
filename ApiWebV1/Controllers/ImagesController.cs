using ApiProjeWeb.Context;
using ApiProjeWeb.Entities;
using Microsoft.AspNetCore.Mvc;
using ApiWebV1.Dtos.ImageDtos;

namespace ApiWebV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ImagesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ImageList()
        {
            var values = _context.Images.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetImage(int id)
        {
            var value = _context.Images.Find(id);
            if (value == null)
            {
                return NotFound("Görsel bulunamadı");
            }

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage([FromForm] CreateImageDto createImageDto)
        {
            if (createImageDto.Photo == null || createImageDto.Photo.Length == 0)
            {
                return BadRequest("Lütfen bir görsel seçin.");
            }

            var extension = Path.GetExtension(createImageDto.Photo.FileName);
            var fileName = Guid.NewGuid().ToString() + extension;
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await createImageDto.Photo.CopyToAsync(stream);
            }

            var image = new Image
            {
                Title = createImageDto.Title,
                ImageUrl = "/images/" + fileName
            };

            _context.Images.Add(image);
            _context.SaveChanges();

            return Ok("Görsel ekleme işlemi başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateImage([FromForm] UpdateImageDto updateImageDto)
        {
            var value = _context.Images.Find(updateImageDto.ImageId);
            if (value == null)
            {
                return NotFound("Görsel bulunamadı");
            }

            value.Title = updateImageDto.Title;

            if (updateImageDto.Photo != null && updateImageDto.Photo.Length > 0)
            {
                var extension = Path.GetExtension(updateImageDto.Photo.FileName);
                var fileName = Guid.NewGuid().ToString() + extension;
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updateImageDto.Photo.CopyToAsync(stream);
                }

                value.ImageUrl = "/images/" + fileName;
            }

            _context.SaveChanges();
            return Ok("Görsel güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteImage(int id)
        {
            var value = _context.Images.Find(id);
            if (value == null)
            {
                return NotFound("Görsel bulunamadı");
            }

            _context.Images.Remove(value);
            _context.SaveChanges();
            return Ok("Görsel silme işlemi başarılı");
        }
    }
}