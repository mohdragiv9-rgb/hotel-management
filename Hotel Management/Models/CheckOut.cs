namespace HotelManagement.Models
{
    public class CheckOut
    {
        public int CheckOutId { get; set; }
        public int CheckInId { get; set; }
        public int BookingId { get; set; }
        public int GuestId { get; set; }
        public int RoomId { get; set; }

        public DateTime CheckOutDateTime { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public int TotalDays { get; set; }

        public decimal RoomCharge { get; set; }

        public decimal ExtraCharge { get; set; }

        public decimal Discount { get; set; }

        public decimal GST { get; set; }

        public decimal GrandTotal { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal BalanceAmount { get; set; }

        public string? Remarks { get; set; }

        public string? GuestName { get; set; }

        public string? RoomNumber { get; set; }

        public string? BookingNo { get; set; }
    }
}