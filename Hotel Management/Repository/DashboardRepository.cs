using Dapper;
using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using System.Data;

namespace HotelManagement.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly DapperContext _context;

        public DashboardRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<DashboardViewModel> GetDashboard()
        {
            using var con = _context.CreateConnection();

            return await con.QueryFirstOrDefaultAsync<DashboardViewModel>(
                "USP_Dashboard",
                commandType: CommandType.StoredProcedure);
        }
    }
}