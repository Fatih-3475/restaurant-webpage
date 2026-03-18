using ApiProjeWeb.Context;
using ApiProjeWeb.Dtos.ProductDto;
using ApiProjeWeb.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, ApiContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _context.Products.ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Ürün ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")] // DÜZELTİLDİ
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            if (value == null) return NotFound("Ürün bulunamadı.");

            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("{id}")] // DÜZELTİLDİ: api/Products/5 şeklinde çalışır
        public IActionResult GetProduct(int id)
        {
            var value = _context.Products.Find(id);
            if (value == null) return NotFound("Ürün bulunamadı.");
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok("Ürün güncelleme işlemi başarılı");
        }

        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _context.Products.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var value = _context.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(value));
        }
    }
}