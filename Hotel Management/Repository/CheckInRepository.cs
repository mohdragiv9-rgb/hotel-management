using Dapper;
using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using System.Data;

namespace HotelManagement.Repository
{
    public class CheckInRepository : ICheckInRepository
    {
        private readonly DapperContext _context;

        public CheckInRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<CheckIn>> GetAll()
        {
            using var con = _context.CreateConnection();

            var data = await con.QueryAsync<CheckIn>(
                "USP_CheckIn",
                new { Action = "SELECT" },
                commandType: CommandType.StoredProcedure);

            return data.ToList();
        }

        public async Task<CheckIn?> GetById(int id)
        {
            using var con = _context.CreateConnection();

            return await con.QueryFirstOrDefaultAsync<CheckIn>(
                "USP_CheckIn",
                new
                {
                    Action = "SELECTBYID",
                    CheckInId = id
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Save(CheckIn model)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_CheckIn",
                new
                {
                    Action = "INSERT",
                    model.BookingId,
                    model.GuestId,
                    model.RoomId,
                    model.CheckInDateTime,
                    model.IDProofType,
                    model.IDProofNo,
                    model.TotalGuest,
                    model.Remarks
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int id)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_CheckIn",
                new
                {
                    Action = "DELETE",
                    CheckInId = id
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
