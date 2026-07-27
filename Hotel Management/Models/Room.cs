namespace HotelManagement.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        public string RoomNumber { get; set; } = string.Empty;

        public int RoomTypeId { get; set; }

        public string? RoomTypeName { get; set; }

        public int FloorNo { get; set; }

        public int Capacity { get; set; }

        public decimal Price { get; set; }

        public string ACType { get; set; } = string.Empty;

        public string RoomStatus { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; }
    }
}