namespace HotelManagement.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }

        public string ? RoomTypeName { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
