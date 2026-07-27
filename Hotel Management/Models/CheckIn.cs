namespace HotelManagement.Models
{
    public class CheckIn
    {

        public int CheckId { get; set; }
        public int BookingId { get; set; }
        public string? BookingNo { get; set; }
        public int  GuestId { get; set; }
        public string? GuestName { get; set; }
        public int  RoomId { get; set; }
        public string? RoomNumber { get; set; }
        public  DateTime CheckInDateTime { get; set; }
        public string? IDProofType { get; set; }
        public string? IDProofNo { get; set; }
        public int  TotalGuest { get; set; }
        public string? Remarks { get; set; }
      
      
    }
}
