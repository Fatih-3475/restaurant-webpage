using ApiProjeWeb.Context;
using ApiProjeWeb.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiWebV1.Dtos.ImageDtos;

namespace ApiWebV1.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public ImagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ImageList()
        {
            var values = _context.Images.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateImage(CreateImageDto createImageDto)
        {
            // _context.Images.Add(Image);    // mapping işlemi yapıcaz burda
            //_context.SaveChanges();
            var value = _mapper.Map<Image>(createImageDto);
            _context.Images.Add(value);
            _context.SaveChanges();
            return Ok("Görsel ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteImage(int id)
        {
            var value = _context.Images.Find(id);
            _context.Images.Remove(value!);
            _context.SaveChanges();
            return Ok("Görsel silme işlemi başarılı");
        }

        [HttpGet("GetImage/{id}")]
        public IActionResult GetImage(int id)
        {
            var value = _context.Images.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateImage(UpdateImageDto updateImageDto)
        {
            var value = _mapper.Map<Image>(updateImageDto);
            _context.Images.Update(value);
            _context.SaveChanges();
            return Ok("Görsel güncelleme işlemi başarılı");
        }
    }
}
