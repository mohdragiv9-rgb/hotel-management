namespace HotelManagement.Models
{
    public class ReportViewModel
    {
        public string? BookingNo { get; set; }

        public string? GuestName { get; set; }

        public string? RoomNumber { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public decimal GrandTotal { get; set; }

        public string? PaymentMode { get; set; }

        public string? BookingStatus { get; set; }
    }
}