using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DatabaseRoomRepository : IRoomRepository
    {
        private readonly AsyncInnDbContext _context;
        public DatabaseRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddRoomAmenity(int roomId, int amenityId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            var amenity = await _context.Amenities.FindAsync(amenityId);
            var roomAmenity = await _context.RoomAmenities.FindAsync(roomId, amenityId); // make sure it doesnt exist, probably a better way to do.
            if (room == null || amenity == null || roomAmenity != null)
            {
                return false;
            }
            roomAmenity = new RoomAmenity
            {
                RoomID = roomId,
                AmenityID = amenityId
            };

            _context.RoomAmenities.Add(roomAmenity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task CreateRoom(Room room)
        {
            _context.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(Room room)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<bool> RemoveRoomAmenity(int roomId, int amenityId)
        {
            var roomAmenity = await _context.RoomAmenities.FindAsync(roomId, amenityId);
            if (roomAmenity == null)
                return false;
            
            _context.RoomAmenities.Remove(roomAmenity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Save worked
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(room.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }

    }
}
