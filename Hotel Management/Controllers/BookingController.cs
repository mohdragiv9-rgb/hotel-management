using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelManagement.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IRoomRepository _roomRepository;

        public BookingController(
            IBookingRepository bookingRepository,
            IGuestRepository guestRepository,
            IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _guestRepository = guestRepository;
            _roomRepository = roomRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Guests = new SelectList(
                await _guestRepository.GetAll(),
                "GuestId",
                "GuestName");

            ViewBag.Rooms = new SelectList(
                await _roomRepository.GetAll(),
                "RoomId",
                "RoomNumber");
            ViewBag.BookingNo = await _bookingRepository.GetBookingNo();

            var data = await _bookingRepository.GetAll();

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _bookingRepository.GetById(id);

            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Booking booking)
        {
            Console.WriteLine("BookingNo = " + booking.BookingNo);

            try
            {
                if (booking.BookingId == 0)
                    await _bookingRepository.Save(booking);
                else
                    await _bookingRepository.Update(booking);

                return Json(new
                {
                    success = true,
                    message = "Booking Saved Successfully"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookingRepository.Delete(id);

            return Json(new
            {
                success = true,
                message = "Booking Deleted Successfully"
            });
        }
    }
}
