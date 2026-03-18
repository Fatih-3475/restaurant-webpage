using ApiProjeWeb.Context;
using ApiProjeWeb.Dtos.ContactDtos;
using ApiProjeWeb.Entities;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly ApiContext _context;
    public ContactsController(ApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult ContactList()
    {
        var values = _context.Contacts.ToList();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateContact(CreateContactDto createContactDto)
    {
        Contact contact = new Contact
        {
            Email = createContactDto.Email,
            Address = createContactDto.Address,
            Phone = createContactDto.Phone,
            MapLocation = createContactDto.MapLocation,
            OpenHours = createContactDto.OpenHours
        };
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return Ok("Ekleme işlemi başarılı");
    }

    [HttpDelete("{id}")] // Düzeltildi
    public IActionResult DeleteContact(int id)
    {
        var value = _context.Contacts.Find(id);
        if (value == null) return NotFound("İletişim bulunamadı");
        _context.Contacts.Remove(value);
        _context.SaveChanges();
        return Ok("Silme işlemi başarılı");
    }

    [HttpGet("{id}")] // Düzeltildi
    public IActionResult GetContact(int id)
    {
        var value = _context.Contacts.Find(id);
        if (value == null) return NotFound("İletişim bulunamadı");
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateContact(UpdateContactDto updateContactDto)
    {
        var contact = new Contact
        {
            ContactId = updateContactDto.ContactId,
            Email = updateContactDto.Email,
            Address = updateContactDto.Address,
            Phone = updateContactDto.Phone,
            MapLocation = updateContactDto.MapLocation,
            OpenHours = updateContactDto.OpenHours
        };
        _context.Contacts.Update(contact);
        _context.SaveChanges();
        return Ok("Başarıyla Güncellendi");
    }
}