using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly IRoomTypeRepository _repository;

        public RoomTypeController(IRoomTypeRepository repository)
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
        public async Task<IActionResult> Save(RoomType model)
        {
            if (model.RoomTypeId == 0)
            {
                await _repository.Save(model);
            }
            else
            {
                await _repository.Update(model);
            }

            return Json(new
            {
                success = true,
                message = "Data Saved Successfully"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);

            return Json(new
            {
                success = true,
                message = "Data Deleted Successfully"
            });
        }
    }
}