namespace ApiProjeWeb.UI.Dtos.ImageDto
{
    public class CreateImageDto
    {
        public string? Title { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
