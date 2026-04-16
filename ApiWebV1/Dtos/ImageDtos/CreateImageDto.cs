namespace ApiWebV1.Dtos.ImageDtos
{
    public class CreateImageDto
    {
        public string? Title { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
