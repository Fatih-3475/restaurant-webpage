using ApiProjeWeb.UI.Dtos.MessageDtos;
using ApiProjeWeb.UI.Dtos.ReservationDto;

namespace ApiProjeWeb.UI.Models
{
    public class AdminDashboardViewModel
    {
        public int CategoryCount { get; set; }
        public int ProductCount { get; set; }
        public int ReservationCount { get; set; }
        public int UnreadMessageCount { get; set; }

        public decimal AverageProductPrice { get; set; }
        public string MostExpensiveProductName { get; set; } = string.Empty;
        public decimal MostExpensiveProductPrice { get; set; }

        public string CheapestProductName { get; set; } = string.Empty;
        public decimal CheapestProductPrice { get; set; }

        public List<ResultMessageDto> LastMessages { get; set; } = new();
        public List<ResultReservationDto> LastReservations { get; set; } = new();

        public Dictionary<string, int> ProductCountByCategory { get; set; } = new();
    }
}