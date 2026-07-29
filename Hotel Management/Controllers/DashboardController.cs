using HotelManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        //git practical
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var model = await _dashboardRepository.GetDashboard();

            return View(model);
        }
    }
}