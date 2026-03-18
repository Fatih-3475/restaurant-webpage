using ApiProjeWeb.Context;

using ApiProjeWeb.Entities;
using ApiWebV1.Dtos.NotificationDtos;
using ApiWebV1.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public NotificationController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _context.Notifications.ToList();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var value = _mapper.Map<Notification>(createNotificationDto);
            _context.Notifications.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")] // DÜZELTİLDİ: id yolu eklendi
        public IActionResult DeleteNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            if (value == null) return NotFound("Öne çıkan içerik bulunamadı."); // Güvenlik eklendi

            _context.Notifications.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("{id}")] // DÜZELTİLDİ: "GetNotification" yerine direkt {id} kullanımı Swagger için daha sağlıklıdır
        public IActionResult GetNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            if (value == null) return NotFound("Öne çıkan içerik bulunamadı.");

            return Ok(_mapper.Map<GetNotificationByIdDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var value = _mapper.Map<Notification>(updateNotificationDto);
            _context.Notifications.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
