using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class GuestController : Controller
    {
        private readonly IGuestRepository _repository;

        public GuestController(IGuestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _repository.GetAll();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _repository.GetById(id);

            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Guest guest)
        {
            try
            {
                if (guest.GuestId == 0)
                    await _repository.Save(guest);
                else
                    await _repository.Update(guest);

                return Json(new
                {
                    success = true,
                    message = "Guest Saved Successfully"
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
        //testing git
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);

            return Json(new
            {
                success = true,
                message = "Guest Deleted Successfully"
            });
        }
    }
}