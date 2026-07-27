using Dapper;
using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using System.Data;

namespace HotelManagement.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DapperContext _context;

        public BookingRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAll()
        {
            using var con = _context.CreateConnection();

            var data = await con.QueryAsync<Booking>(
                "USP_Booking",
                new { Action = "SELECT" },
                commandType: CommandType.StoredProcedure);

            return data.ToList();
        }

        public async Task<Booking?> GetById(int id)
        {
            using var con = _context.CreateConnection();

            return await con.QueryFirstOrDefaultAsync<Booking>(
                "USP_Booking",
                new
                {
                    Action = "SELECTBYID",
                    BookingId = id
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Save(Booking booking)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_Booking",
                new
                {
                    Action = "INSERT",
                    booking.BookingNo,
                    booking.GuestId,
                    booking.RoomId,
                    booking.CheckInDate,
                    booking.CheckOutDate,
                    booking.Adults,
                    booking.Children,
                    booking.TotalAmount,
                    booking.AdvanceAmount,
                    booking.BalanceAmount,
                    booking.Remarks
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Booking booking)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_Booking",
                new
                {
                    Action = "UPDATE",
                    booking.BookingId,
                    booking.GuestId,
                    booking.RoomId,
                    booking.CheckInDate,
                    booking.CheckOutDate,
                    booking.Adults,
                    booking.Children,
                    booking.TotalAmount,
                    booking.AdvanceAmount,
                    booking.BalanceAmount,
                    booking.Remarks
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int id)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_Booking",
                new
                {
                    Action = "DELETE",
                    BookingId = id
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> GetBookingNo()
        {
            using var con = _context.CreateConnection();

            return await con.QueryFirstOrDefaultAsync<string>( "USP_Booking", new  { Action = "GETBOOKINGNO" }, commandType: CommandType.StoredProcedure);
        }
    }
}
