namespace ApiProjeWeb.UI.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? MessageDetails { get; set; }
        public DateTime SendData { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }
    }
}
