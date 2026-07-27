namespace HotelManagement.Models
{
    public class Guest
    {
        public int GuestId { get; set; }

        public string GuestName { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public string? Email { get; set; }
        public string? IdProofType { get; set; }
        public string? IdProofNumber { get; set; }
        public string? AadhaarNo { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? Pincode { get; set; }

        public bool IsActive { get; set; }
    }
}