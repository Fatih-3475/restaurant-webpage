namespace ApiProjeWeb.UI.Dtos.AboutDtos
{
    public class GetAboutByIdDto
    {
        public int AboutId { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? VideoCoverImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string? Descripton { get; set; }
        public string? ReservationNumber { get; set; }
    }
}
