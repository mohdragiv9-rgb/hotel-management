using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelManagement.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly ICheckOutRepository _repository;

        public CheckOutController(ICheckOutRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _repository.GetAll();

            var bookings = await _repository.GetBookingList();

            ViewBag.Bookings = new SelectList(bookings, "BookingId", "BookingNo");

            return View(data);
        }
        
        
        
        [HttpGet]
        public async Task<IActionResult> GetBookingDetails(int bookingId)
        {
            var data = await _repository.GetBookingDetails(bookingId);

            if (data == null)
            {
                return Json(null);
            }

            return Json(new
            {
                checkInId = data.CheckInId,     
                guestId = data.GuestId,
                roomId = data.RoomId,
                guestName = data.GuestName,
                roomNumber = data.RoomNumber,
                checkInDate = data.CheckInDate,
                checkOutDate = data.CheckOutDate,
                roomCharge = data.TotalAmount    
            });
        
        }
        [HttpPost]
        public async Task<IActionResult> Save(CheckOut model)
        {
            await _repository.Save(model);

            return Json(new
            {
                success = true,
                message = "Check-Out Completed Successfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _repository.GetById(id);

            if (data == null)
                return Json(null);

            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);

            return Json(new
            {
                success = true,
                message = "Deleted Successfully"
            });
        }
    }
}