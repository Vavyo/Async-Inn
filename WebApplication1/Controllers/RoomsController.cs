using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly AsyncInnDbContext _context;
        private readonly IRoomRepository roomRepository;

        public RoomsController(AsyncInnDbContext context, IRoomRepository roomRepository)
        {
            _context = context;
            this.roomRepository = roomRepository;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return Ok(await roomRepository.GetAllRooms());
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await roomRepository.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }
            
            if (!await roomRepository.UpdateRoom(room))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            await roomRepository.CreateRoom(room);

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await roomRepository.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            await roomRepository.DeleteRoom(room);

            return NoContent();
        }

        // Room Amenity Actions:
        [HttpPost("{roomId}/Amenities/{amenityId}")]
        public async Task<IActionResult> AddAmenity(int roomId, int amenityId)
        {
            if (await roomRepository.AddRoomAmenity(roomId, amenityId))
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{roomId}/Amenities/{amenityId}")]
        public async Task<IActionResult> RemoveAmenity(int roomId, int amenityId)
        {
            if (await roomRepository.AddRoomAmenity(roomId, amenityId))
                return NotFound();
            return NoContent();
        }
    }
}
