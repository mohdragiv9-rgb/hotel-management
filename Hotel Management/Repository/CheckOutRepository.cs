using Dapper;
using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using System.Data;

namespace HotelManagement.Repository
{
    public class CheckOutRepository : ICheckOutRepository
    {
        private readonly DapperContext _context;

        public CheckOutRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetBookingList()
        {
            using var con = _context.CreateConnection();

            var result = await con.QueryAsync<Booking>(
                "USP_Booking",
                new { Action = "SELECT" },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public async Task<List<CheckOut>> GetAll()
        {
            using var con = _context.CreateConnection();

            var result = await con.QueryAsync<CheckOut>(
                "USP_CheckOut",
                new
                {
                    Action = "SELECT"
                },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public async Task<CheckOut?> GetById(int id)
        {
            using var con = _context.CreateConnection();

            return await con.QueryFirstOrDefaultAsync<CheckOut>(
                "USP_CheckOut",
                new
                {
                    Action = "SELECTBYID",
                    CheckOutId = id
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<Booking?> GetBookingDetails(int bookingId)
        {
            using var con = _context.CreateConnection();

            return await con.QueryFirstOrDefaultAsync<Booking>(
                "USP_Booking",
                new
                {
                    Action = "SELECTBYID",
                    BookingId = bookingId
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<int> Save(CheckOut model)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_CheckOut",
                new
                {
                    Action = "INSERT",
                    model.CheckInId,
                    model.BookingId,
                    model.GuestId,
                    model.RoomId,
                    model.CheckOutDateTime,
                    model.TotalDays,
                    model.RoomCharge,
                    model.ExtraCharge,
                    model.Discount,
                    model.GST,
                    model.GrandTotal,
                    model.PaidAmount,
                    model.BalanceAmount,
                    model.Remarks
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int id)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_CheckOut",
                new
                {
                    Action = "DELETE",
                    CheckOutId = id
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}