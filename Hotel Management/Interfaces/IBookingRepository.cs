using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAll();

        Task<Booking?> GetById(int id);

        Task<int> Save(Booking booking);

        Task<int> Update(Booking booking);

        Task<int> Delete(int id);

        Task<string> GetBookingNo();

    }
}