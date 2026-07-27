namespace HotelManagement.Models
{
    public class InvoiceViewModel
    {
        public string HotelName { get; set; } = "";

        public string HotelAddress { get; set; } = "";

        public string HotelPhone { get; set; } = "";

        public string BookingNo { get; set; } = "";

        public string GuestName { get; set; } = "";

        public string RoomNumber { get; set; } = "";

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int TotalDays { get; set; }

        public decimal RoomCharge { get; set; }

        public decimal ExtraCharge { get; set; }

        public decimal Discount { get; set; }

        public decimal GST { get; set; }

        public decimal GrandTotal { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal BalanceAmount { get; set; }

        public string PaymentMode { get; set; } = "";
    }
}