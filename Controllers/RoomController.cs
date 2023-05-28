using BigBangAssessment.Models;
using BigBangAssessment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BigBangAssessment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public ActionResult<ICollection<Room>> GetAllRooms()
        {
            var hotels = _roomRepository.GetRooms();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public ActionResult<ICollection<Room>> GetRoomById(int id)
        {
            var rooms = _roomRepository.GetRoomById(id);
            return Ok(rooms);
        }

        [HttpPost]
        public ActionResult<ICollection<Room>> CreateRoom(Room rooms)
        {
            _roomRepository.AddRoom(rooms);
            return Ok(rooms);
        }


        [HttpPut("{id}")]
        public ActionResult<ICollection<Room>> UpdateRoom(Room rooms)
        {
            _roomRepository.UpdateRoom(rooms);
            return Ok(rooms);
        }

        [HttpDelete("{id}")]
        public ActionResult<ICollection<Room>> DeleteRoom(int id)
        {
            _roomRepository.DeleteRoom(id);
            return Ok(id);
        }

    }
}
