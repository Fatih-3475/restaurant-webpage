namespace ApiProjeWeb.UI.Dtos.MessageDtos
{
    public class ResultMessageDto
    {
        public int MessegaId { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? MessageDetails { get; set; }
        public DateTime SendData { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }
    }
}
