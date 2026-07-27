using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface ICheckOutRepository
    {
        Task<List<CheckOut>> GetAll();

        Task<CheckOut?> GetById(int id);

        Task<int> Save(CheckOut model);

        Task<int> Delete(int id);

        Task<List<Booking>> GetBookingList();

        Task<Booking?> GetBookingDetails(int bookingId);
    }
}