using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data.Interfaces
{
    public interface IHotelRoomRepository
    {
        Task AddHotelRoom(int hotelId, CreateHotelRoom hotelRoom);
        Task<HotelRoom> GetHotelRoom(int hotelId, int number);
        Task<bool> UpdateHotelRoom(HotelRoom hotelRoom);
        Task<IEnumerable<HotelRoom>> GetAllHotelRooms(int hotelId);
        Task DeleteHotelRoom(HotelRoom hotelRoom);
    }
}
