using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface ILoginRepository
    {
        Task<User?> Login(string userName, string password);
    }
}