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
            var rooms = await _roomRepository.GetAll();

            var roomTypes = await _roomTypeRepository.GetAll();

            ViewBag.RoomTypes = new SelectList(
                roomTypes,
                "RoomTypeId",
                "RoomTypeName"
                
            );

            ViewBag.Prices = new SelectList(
                roomTypes,
                "Price",
                "Price"
            );

            return View(rooms);
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