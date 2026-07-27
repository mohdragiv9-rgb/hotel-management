using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomController(IRoomRepository roomRepository,
                              IRoomTypeRepository roomTypeRepository)
        {
            _roomRepository = roomRepository;
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.RoomTypes = new SelectList(
                await _roomTypeRepository.GetAll(),
                "RoomTypeId",
                "RoomTypeName");

            var data = await _roomRepository.GetAll();

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _roomRepository.GetById(id);

            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Room room)
        {
            if (room.RoomId == 0)
                await _roomRepository.Save(room);
            else
                await _roomRepository.Update(room);

            return Json(new
            {
                success = true,
                message = "Saved Successfully"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomRepository.Delete(id);

            return Json(new
            {
                success = true,
                message = "Deleted Successfully"
            });
        }
    }
}