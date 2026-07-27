using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface IGuestRepository
    {
        Task<List<Guest>> GetAll();

        Task<Guest?> GetById(int id);

        Task<int> Save(Guest guest);

        Task<int> Update(Guest guest);

        Task<int> Delete(int id);
    }
}