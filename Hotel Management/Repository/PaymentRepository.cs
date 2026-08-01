using Dapper;
using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using System.Data;

namespace HotelManagement.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DapperContext _context;

        public PaymentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAll()
        {
            using var con = _context.CreateConnection();

            var data = await con.QueryAsync<Payment>(
                "USP_Payment",
                new { Action = "SELECT" },
                commandType: CommandType.StoredProcedure);

            return data.ToList();
        }

        public async Task<Payment?> GetById(int id)
        {
            using var con = _context.CreateConnection();

            return await con.QueryFirstOrDefaultAsync<Payment>(
                "USP_Payment",
                new
                {
                    Action = "SELECTBYID",
                    PaymentId = id
                },
                commandType: CommandType.StoredProcedure);
        }

        //public async Task<int> Save(Payment payment)
        //{
        //    using var con = _context.CreateConnection();

        //    return await con.ExecuteAsync(
        //        "USP_Payment",
        //        new
        //        {
        //            Action = "INSERT",
        //            payment.CheckOutId,
        //            payment.BookingId,
        //            payment.GuestId,
        //            payment.Amount,
        //            payment.PaymentMode,
        //            payment.TransactionNo,
        //            payment.Remarks
        //        },
        //        commandType: CommandType.StoredProcedure);
        //}
        public async Task<int> Save(Payment payment)
        {
            using var con = _context.CreateConnection();

            string action = payment.PaymentId == 0
                            ? "INSERT"
                            : "UPDATE";

            return await con.ExecuteAsync(
                "USP_Payment",
                new
                {
                    Action = action,

                    PaymentId = payment.PaymentId,

                    payment.CheckOutId,
                    payment.BookingId,
                    payment.GuestId,         
                    payment.Amount,
                    payment.PaymentMode,
                    payment.TransactionNo,
                    payment.Remarks
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int id)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_Payment",
                new
                {
                    Action = "DELETE",
                    PaymentId = id
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}