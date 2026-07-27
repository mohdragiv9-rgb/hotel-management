using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface IDashboardRepository
    {
        Task<DashboardViewModel> GetDashboard();
    }
}