using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelManagement.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IPaymentRepository _repository;


        public PaymentController(
            IPaymentRepository repository,
            IBookingRepository bookingRepository,
            IGuestRepository guestRepository)
        {
            _repository = repository;
            _bookingRepository = bookingRepository;
            _guestRepository = guestRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Bookings = new SelectList(
                await _bookingRepository.GetAll(),
                "BookingId",
                "BookingNo");

            ViewBag.Guests = new SelectList(
                await _guestRepository.GetAll(),
                "GuestId",
                "GuestName");

            var data = await _repository.GetAll();

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Payment payment)
        {
            try
            {
                await _repository.Save(payment);

                return Json(new
                {
                    success = true,
                    message = "Payment Saved Successfully"
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

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _repository.GetById(id);

            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);

            return Json(new
            {
                success = true,
                message = "Payment Deleted Successfully"
            });
        }
    }
}