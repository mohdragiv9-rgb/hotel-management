namespace HotelManagement.Models
{
    public class DashboardViewModel
    {
        public int TotalRooms { get; set; }

        public int AvailableRooms { get; set; }

        public int OccupiedRooms { get; set; }

        public int TotalGuests { get; set; }

        public int TotalBookings { get; set; }

        public int TotalCheckIn { get; set; }

        public int TotalCheckOut { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}