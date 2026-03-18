using ApiProjeWeb.Context;
using ApiProjeWeb.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ChefsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var value = _context.Chefs.ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult ChefPost(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Yeni Chef eklendi.");
        }

        // DÜZELTİLDİ: id'nin URL üzerinden geleceğini süslü parantez ile belirttik
        [HttpDelete("{id}")]
        public IActionResult DeleteChef(int id)
        {
            var value = _context.Chefs.Find(id);
            if (value == null) return NotFound("Chef bulunamadı"); // Hata almamak için kontrol ekledik

            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Chef sistemden silindi");
        }

        // DÜZELTİLDİ: URL yapısını "api/Chefs/5" formatına çektik
        [HttpGet("{id}")]
        public IActionResult GetChef(int id)
        {
            var value = _context.Chefs.Find(id);
            if (value == null) return NotFound("Chef bulunamadı");
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Chef güncelleme başarılı");
        }
    }
}