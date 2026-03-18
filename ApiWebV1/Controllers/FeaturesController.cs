using ApiProjeWeb.Context;
using ApiProjeWeb.Dtos.FeatureDtos;
using ApiProjeWeb.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")] // DÜZELTİLDİ: id yolu eklendi
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            if (value == null) return NotFound("Öne çıkan içerik bulunamadı."); // Güvenlik eklendi

            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("{id}")] // DÜZELTİLDİ: "GetFeature" yerine direkt {id} kullanımı Swagger için daha sağlıklıdır
        public IActionResult GetFeature(int id)
        {
            var value = _context.Features.Find(id);
            if (value == null) return NotFound("Öne çıkan içerik bulunamadı.");

            return Ok(_mapper.Map<GetByIdFeatureDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            _context.Features.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}