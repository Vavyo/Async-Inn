using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/Hotel/{hotelId}/Room")]
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        private readonly IHotelRoomRepository hotelRoomRepository;

        public HotelRoomController(IHotelRoomRepository hotelRoomRepository)
        {
            this.hotelRoomRepository = hotelRoomRepository;
        }

        // GET: api/<HotelRoomController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> Get(int hotelId)
        {
            return Ok(await hotelRoomRepository.GetAllHotelRooms(hotelId));
        }

        // GET api/<HotelRoomController>/5
        [HttpGet("{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> Get(int hotelId, int roomNumber)
        {
            var hotelRoom = await hotelRoomRepository.GetHotelRoom(hotelId, roomNumber);
            if (hotelRoom == null)
            {
                return BadRequest();
            }

            return hotelRoom;
        }

        // POST api/<HotelRoomController>
        [HttpPost]
        public async Task Post(int hotelId, [FromBody] CreateHotelRoom hotelRoom)
        {
            await hotelRoomRepository.AddHotelRoom(hotelId, hotelRoom);
        }

        // PUT api/<HotelRoomController>/5
        [HttpPut("{roomNumber}")]
        public async Task<IActionResult> Put(int hotelId, int roomNumber, [FromBody] HotelRoom hotelRoom)
        {
            if (roomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            if (!await hotelRoomRepository.UpdateHotelRoom(hotelRoom))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<HotelRoomController>/5
        [HttpDelete("{roomNumber}")]
        public async Task<IActionResult> Delete(int hotelId, int roomNumber)
        {
            var hotelRoom = await hotelRoomRepository.GetHotelRoom(hotelId, roomNumber);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            await hotelRoomRepository.DeleteHotelRoom(hotelRoom);

            return NoContent();

        }
    }
}
