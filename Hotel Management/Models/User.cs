namespace HotelManagement.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? MobileNo { get; set; }

        public string Role { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}