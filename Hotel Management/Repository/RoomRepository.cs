using Dapper;
using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using System.Data;

namespace HotelManagement.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DapperContext _context;

        public RoomRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> GetAll()
        {
            using var con = _context.CreateConnection();

            var data = await con.QueryAsync<Room>(
                "USP_Room",
                new { Action = "SELECT" },
                commandType: CommandType.StoredProcedure);

            return data.ToList();
        }

        public async Task<Room?> GetById(int id)
        {
            using var con = _context.CreateConnection();

            return await con.QueryFirstOrDefaultAsync<Room>(
                "USP_Room",
                new
                {
                    Action = "SELECTBYID",
                    RoomId = id
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Save(Room room)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_Room",
                new
                {
                    Action = "INSERT",
                    room.RoomNumber,
                    room.RoomTypeId,
                    room.FloorNo,
                    room.Capacity,
                    room.Price,
                    room.ACType,
                    room.RoomStatus,
                    room.Description
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Room room)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_Room",
                new
                {
                    Action = "UPDATE",
                    room.RoomId,
                    room.RoomNumber,
                    room.RoomTypeId,
                    room.FloorNo,
                    room.Capacity,
                    room.Price,
                    room.ACType,
                    room.RoomStatus,
                    room.Description
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int id)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_Room",
                new
                {
                    Action = "DELETE",
                    RoomId = id
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}