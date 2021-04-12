using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllHotels();

        Task CreateHotel(Hotel hotel);

        Task<Hotel> GetHotel(int id);

        Task<bool> UpdateHotel(Hotel hotel);

        Task DeleteHotel(Hotel hotel);
    }
}