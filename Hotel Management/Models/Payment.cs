namespace HotelManagement.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int CheckOutId { get; set; }

        public int BookingId { get; set; }

        public int GuestId { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMode { get; set; } = string.Empty;

        public string? TransactionNo { get; set; }

        public DateTime PaymentDate { get; set; }

        public string? Remarks { get; set; }

        public string? GuestName { get; set; }

        public string? BookingNo { get; set; }
    }
}