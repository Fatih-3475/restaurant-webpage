namespace ApiWebV1.Dtos.ImageDtos
{
    public class ResultImageDto
    {
        public int ImageId { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
