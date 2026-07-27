using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface ICheckInRepository
    {
        Task<List<CheckIn>> GetAll();

        Task<CheckIn?> GetById(int id);

        Task<int> Save(CheckIn model);

        Task<int> Delete(int id);
    }
}