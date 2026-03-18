using ApiProjeWeb.Context;
using ApiProjeWeb.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;
        public ServicesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _context.Services.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Hizmet ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")] // DÜZELTİLDİ: id yolu eklendi
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            if (value == null) return NotFound("Hizmet bulunamadı.");

            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Hizmet silme işlemi başarılı");
        }

        [HttpGet("{id}")] // DÜZELTİLDİ: GetService yerine direkt id yolu
        public IActionResult GetService(int id)
        {
            var value = _context.Services.Find(id);
            if (value == null) return NotFound("Hizmet bulunamadı.");
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Hizmet güncelleme işlemi başarılı");
        }
    }
}