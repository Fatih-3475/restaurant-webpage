using ApiProjeWeb.Entities;

namespace ApiProjeWeb.Dtos.ProductDto
{
    public class ResultProductWithCategoryDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string? ProductUrl { get; set; }
        public int? CategoryId { get; set; }
        public object? CategoryName { get; internal set; }
    }
}
