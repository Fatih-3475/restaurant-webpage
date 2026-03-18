namespace ApiProjeWeb.Dtos.MessegeDtos
{
    public class GetByIdMessegeDto
    {
        public int MessegaId { get; set; }
        public string NameSurname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string MessageDetails { get; set; } = null!;
        public DateTime SendData { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }
    }
}
