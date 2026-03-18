namespace ApiWebV1.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
        public DateTime NotificationDate { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }
    }
}
