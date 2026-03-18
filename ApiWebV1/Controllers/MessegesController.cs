using ApiProjeWeb.Context;
using ApiProjeWeb.Dtos.MessegeDtos;
using ApiProjeWeb.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessegesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public MessegesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult MessegeList()
        {
            var value = _context.Messegas.ToList();
            return Ok(_mapper.Map<List<ResultMessegeDto>>(value));
        }

        [HttpPost]
        public IActionResult CreateMessege0(CreateMessegeDto createMessegeDto)
        {
            var value = _mapper.Map<Messega>(createMessegeDto);
            _context.Messegas.Add(value);
            _context.SaveChanges();
            return Ok("Mesaj ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")] // DÜZELTİLDİ: id yolu eklendi
        public IActionResult DeleteMessege(int id)
        {
            var value = _context.Messegas.Find(id);
            if (value == null) return NotFound("Mesaj bulunamadı."); // Güvenlik kontrolü

            _context.Messegas.Remove(value);
            _context.SaveChanges();
            return Ok("Mesaj başarıyla silindi");
        }

        [HttpGet("{id}")] // DÜZELTİLDİ: GetMessege yerine direkt id yolu
        public IActionResult GetMessege(int id)
        {
            var value = _context.Messegas.Find(id);
            if (value == null) return NotFound("Mesaj bulunamadı.");

            return Ok(_mapper.Map<GetByIdMessegeDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateMessege(UpdateMessegeDto updateMessegeDto)
        {
            var value = _mapper.Map<Messega>(updateMessegeDto);
            _context.Messegas.Update(value);
            _context.SaveChanges();
            return Ok("Mesaj güncelleme işlemi başarılı");
        }
        [HttpGet("MessageListByIsReadFalse")]
        public IActionResult MessageListByIsReadFalse()
        {
            var value = _context.Messegas.Where(x=> x.IsRead == false).ToList();
            return Ok(value);
        }
    }
}