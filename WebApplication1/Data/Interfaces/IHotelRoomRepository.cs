using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data.Interfaces
{
    public interface IHotelRoomRepository
    {
        Task<IEnumerable<HotelRoom>> GetAllHotelRooms();

        Task CreateHotelRoom(HotelRoom hotelRoom);

        Task<HotelRoom> GetHotelRoom(int id, int number);

        Task<bool> UpdateHotelRoom(HotelRoom hotelRoom);

        Task DeleteHotelRoom(HotelRoom hotelRoom);

    }
}
