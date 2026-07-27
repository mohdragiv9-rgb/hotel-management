using Dapper;
using HotelManagement.Models;
using HotelManagement.Data;
using HotelManagement.Interfaces;
using System.Data;

namespace HotelManagement.Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly DapperContext _context;

        public RoomTypeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<RoomType>> GetAll()
        {
            using var connection = _context.CreateConnection();

            var result = await connection.QueryAsync<RoomType>(
                "USP_RoomType",
                new { Action = "SELECT" },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<RoomType> GetById(int id)
        {
            using var connection = _context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<RoomType>(
                "USP_RoomType",
                new
                {
                    Action = "SELECTBYID",
                    RoomTypeId = id
                },
                commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> Save(RoomType roomType)
        {
            using var connection = _context.CreateConnection();

            return await connection.ExecuteAsync(
                "USP_RoomType",
                new
                {
                    Action = "INSERT",
                    roomType.RoomTypeName,
                    roomType.Price,
                    roomType.Description
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(RoomType roomType)
        {
            using var connection = _context.CreateConnection();

            return await connection.ExecuteAsync(
                "USP_RoomType",
                new
                {
                    Action = "UPDATE",
                    roomType.RoomTypeId,
                    roomType.RoomTypeName,
                    roomType.Price,
                    roomType.Description
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int id)
        {
            using var connection = _context.CreateConnection();

            return await connection.ExecuteAsync(
                "USP_RoomType",
                new
                {
                    Action = "DELETE",
                    RoomTypeId = id
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}