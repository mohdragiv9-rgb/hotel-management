using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelManagement.Controllers
{
    public class CheckInController : Controller
    {
        private readonly ICheckInRepository _checkInRepository;
        private readonly IBookingRepository _bookingRepository;

        public CheckInController(
            ICheckInRepository checkInRepository,
            IBookingRepository bookingRepository)
        {
            _checkInRepository = checkInRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Bookings = new SelectList(
                await _bookingRepository.GetAll(),
                "BookingId",
                "BookingNo");

            var data = await _checkInRepository.GetAll();

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(CheckIn model)
        {
            await _checkInRepository.Save(model);

            return Json(new
            {
                success = true,
                message = "Check-In Completed Successfully"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _checkInRepository.Delete(id);

            return Json(new
            {
                success = true,
                message = "Deleted Successfully"
            });
        }
    }
}