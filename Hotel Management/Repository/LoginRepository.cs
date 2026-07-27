using Dapper;
using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using System.Data;

namespace HotelManagement.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DapperContext _context;

        public LoginRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<User?> Login(string userName, string password)
        {
            using var con = _context.CreateConnection();

            return await con.QueryFirstOrDefaultAsync<User>(
                "USP_Login",
                new
                {
                    UserName = userName,
                    Password = password
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
