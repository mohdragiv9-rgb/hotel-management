using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface  IRoomTypeRepository
    {
        Task<List<RoomType>> GetAll();

        Task<RoomType> GetById(int id);

        Task<int> Save(RoomType roomType);

        Task<int> Update(RoomType roomType);

        Task<int> Delete(int id);
    }
}
