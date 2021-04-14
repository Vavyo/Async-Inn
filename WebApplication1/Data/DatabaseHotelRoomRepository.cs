using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DatabaseHotelRoomRepository : IHotelRoomRepository
    {
        public DatabaseHotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        private readonly AsyncInnDbContext _context;

        public async Task AddHotelRoom(int hotelId, CreateHotelRoom createHotelRoom)
        {
            var hotelRoom = new HotelRoom
            {
                HotelId = hotelId,
                RoomNumber = createHotelRoom.RoomNumber,
                RoomId = createHotelRoom.RoomId,
                Rate = createHotelRoom.Rate,
                PetFriendly = createHotelRoom.PetFriendly
            };

            _context.HotelRooms.Add(hotelRoom);
            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoom> GetHotelRoom(int hotelId, int number)
        {
            return await _context.HotelRooms.FindAsync(hotelId, number);
        }

        public async Task<bool> UpdateHotelRoom(int hotelId, CreateHotelRoom createHotelRoom)
        {
            var hotelRoom = new HotelRoom
            {
                HotelId = hotelId,
                RoomNumber = createHotelRoom.RoomNumber,
                RoomId = createHotelRoom.RoomId,
                Rate = createHotelRoom.Rate,
                PetFriendly = createHotelRoom.PetFriendly
            };

            _context.Entry(hotelRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Save worked
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelRoomExists(hotelId, createHotelRoom.RoomNumber))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool HotelRoomExists(int id, int number)
        {
            return _context.HotelRooms.Any(e => e.HotelId == id && e.RoomNumber == number);
        }

        public async Task<IEnumerable<HotelRoom>> GetAllHotelRooms(int hotelId)
        {
            return await _context.HotelRooms.ToListAsync();
        }
    }
}
