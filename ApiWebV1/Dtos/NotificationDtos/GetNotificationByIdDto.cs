namespace ApiWebV1.Dtos.NotificationDtos
{
    public class GetNotificationByIdDto
    {
        public int NotificationId { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
        public DateTime NotificationDate { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }
    }
}
