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
        [HttpGet("{id}")]
        public async Task Get(int hotelId, int number)
        {
            await hotelRoomRepository.GetHotelRoom(hotelId, number);
        }

        // POST api/<HotelRoomController>
        [HttpPost]
        public async Task Post(int hotelId, [FromBody] CreateHotelRoom hotelRoom)
        {
            await hotelRoomRepository.AddHotelRoom(hotelId, hotelRoom);
        }

        // PUT api/<HotelRoomController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int hotelId, int id, [FromBody] CreateHotelRoom hotelRoom)
        {
            if (id != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            if (!await hotelRoomRepository.UpdateHotelRoom(hotelId, hotelRoom))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<HotelRoomController>/5
        [HttpDelete("{id}")]
        public void Delete(int hotelId, int id)
        {
        }
    }
}
