using ApiProjeWeb.Entities;

namespace ApiProjeWeb.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public required List<Product> Products { get; set; }
    }
}
