namespace HotelManagement.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public string BookingNo { get; set; } = string.Empty;

        public int GuestId { get; set; }
        public int CheckInId { get; set; }
        public string? GuestName { get; set; }

        public int RoomId { get; set; }

        public string? RoomNumber { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int Adults { get; set; }

        public int Children { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal AdvanceAmount { get; set; }

        public decimal BalanceAmount { get; set; }

        public string BookingStatus { get; set; } = string.Empty;

        public string? Remarks { get; set; }
    }
}