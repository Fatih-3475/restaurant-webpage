using ApiProjeWeb.Context;
using ApiProjeWeb.Entities;
using ApiWebV1.Dtos.ReservationDtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ReservationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ReservationList()
        {
            var values = _context.Reservations.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateReservation(CreateReservationDto createReservationDto)
        {
            var value = _mapper.Map<Reservation>(createReservationDto);

            value.ReservationDate = DateTime.SpecifyKind(value.ReservationDate, DateTimeKind.Utc);

            _context.Reservations.Add(value);
            _context.SaveChanges();

            return Ok("Rezervasyon ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            var value = _context.Reservations.Find(id);
            if (value == null)
            {
                return NotFound("Rezervasyon bulunamadı");
            }

            _context.Reservations.Remove(value);
            _context.SaveChanges();
            return Ok("Rezervasyon silme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            var value = _context.Reservations.Find(id);
            if (value == null)
            {
                return NotFound("Rezervasyon bulunamadı");
            }

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            var value = _context.Reservations.Find(updateReservationDto.ReservationId);
            if (value == null)
            {
                return NotFound("Rezervasyon bulunamadı");
            }

            _mapper.Map(updateReservationDto, value);
            _context.SaveChanges();
            return Ok("Rezervasyon güncelleme işlemi başarılı");
        }
    }
}