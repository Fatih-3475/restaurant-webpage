using ApiProjeWeb.Context;
using ApiProjeWeb.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _context;
        public TestimonialsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _context.Testimonials.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Referans ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")] // DÜZELTİLDİ: id yolu eklendi
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            if (value == null) return NotFound("Referans bulunamadı.");

            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Referans silme işlemi başarılı");
        }

        [HttpGet("{id}")] // DÜZELTİLDİ: GetTestimonial yerine direkt id yolu
        public IActionResult GetTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            if (value == null) return NotFound("Referans bulunamadı.");
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Referans güncelleme işlemi başarılı");
        }
    }
}