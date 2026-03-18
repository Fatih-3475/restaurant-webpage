namespace ApiProjeWeb.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; } 
        public string? ProductDescription { get; set; } 
        public decimal Price { get; set; }
        public string? ProductUrl { get; set; } 
        public int? CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}
