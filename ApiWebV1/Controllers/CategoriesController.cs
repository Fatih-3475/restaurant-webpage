using ApiProjeWeb.Context;
using ApiProjeWeb.Entities;
using ApiWebV1.Dtos.CategoryDtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
           // _context.Categories.Add(category);    // mapping işlemi yapıcaz burda
           //_context.SaveChanges();
           var value = _mapper.Map<Category>(createCategoryDto);
            _context.Categories.Add(value);
            _context.SaveChanges();
            return Ok("Kategori ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id) 
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value!);
            _context.SaveChanges();
            return Ok("Kategori silme işlemi başarılı");
        }

        [HttpGet("GetCategory/{id}")]
        public IActionResult GetCategory(int id) 
        {
            var value = _context.Categories.Find(id);
            return Ok(value); 
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto) 
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            _context.Categories.Update(value);
            _context.SaveChanges();
            return Ok("Kategori güncelleme işlemi başarılı");
        }
    }
 }
