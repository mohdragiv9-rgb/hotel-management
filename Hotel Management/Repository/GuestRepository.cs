using Dapper;
using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using System.Data;

namespace HotelManagement.Repository
{
    public class GuestRepository : IGuestRepository
    {
        private readonly DapperContext _context;

        public GuestRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Guest>> GetAll()
        {
            using var con = _context.CreateConnection();

            var result = await con.QueryAsync<Guest>(
                "USP_Guest",
                new { Action = "SELECT" },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<Guest?> GetById(int id)
        {
            using var con = _context.CreateConnection();

            return await con.QueryFirstOrDefaultAsync<Guest>(
                "USP_Guest",
                new
                {
                    Action = "SELECTBYID",
                    GuestId = id
                },
                commandType: CommandType.StoredProcedure);
        }

        //public async Task<int> Save(Guest guest)
        //{
        //    using var con = _context.CreateConnection();

        //    return await con.ExecuteAsync(
        //        "USP_Guest",
        //        new
        //        {
        //            Action = "INSERT",
        //            guest.GuestName,
        //            guest.MobileNo,
        //            guest.Email,
        //            guest.AadhaarNo,
        //            guest.Gender,
        //            guest.Address,
        //            guest.City,
        //            guest.State,
        //            guest.Country,
        //            guest.Pincode
        //        },
        //        commandType: CommandType.StoredProcedure);
        //}
        public async Task<int> Save(Guest guest)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_Guest",
                new
                {
                    Action = "INSERT",
                    guest.GuestName,
                    guest.MobileNo,
                    guest.Email,
                    guest.IdProofType,
                    guest.IdProofNumber,
                    guest.AadhaarNo,
                    guest.Gender,
                    guest.Address,
                    guest.City,
                    guest.State,
                    guest.Country,
                    guest.Pincode
                },
                commandType: CommandType.StoredProcedure);
        }
        //public async Task<int> Update(Guest guest)
        //{
        //    using var con = _context.CreateConnection();

        //    return await con.ExecuteAsync(
        //        "USP_Guest",
        //        new
        //        {
        //            Action = "UPDATE",
        //            guest.GuestId,
        //            guest.GuestName,
        //            guest.MobileNo,
        //            guest.Email,
        //            guest.AadhaarNo,
        //            guest.Gender,
        //            guest.Address,
        //            guest.City,
        //            guest.State,
        //            guest.Country,
        //            guest.Pincode
        //        },
        //        commandType: CommandType.StoredProcedure);
        //}
        public async Task<int> Update(Guest guest)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_Guest",
                new
                {
                    Action = "UPDATE",
                    guest.GuestId,
                    guest.GuestName,
                    guest.MobileNo,
                    guest.Email,
                    guest.IdProofType,
                    guest.IdProofNumber,
                    guest.AadhaarNo,
                    guest.Gender,
                    guest.Address,
                    guest.City,
                    guest.State,
                    guest.Country,
                    guest.Pincode
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<int> Delete(int id)
        {
            using var con = _context.CreateConnection();

            return await con.ExecuteAsync(
                "USP_Guest",
                new
                {
                    Action = "DELETE",
                    GuestId = id
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}