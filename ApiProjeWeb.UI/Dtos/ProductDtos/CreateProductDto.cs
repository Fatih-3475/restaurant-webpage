namespace ApiProjeWeb.UI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string? ProductUrl { get; set; }
        public int? CategoryId { get; set; }
    }
}
