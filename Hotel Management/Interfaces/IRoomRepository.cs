using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAll();

        Task<Room?> GetById(int id);

        Task<int> Save(Room room);

        Task<int> Update(Room room);

        Task<int> Delete(int id);
    }
}