using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();

        Task CreateRoom(Room room);

        Task<Room> GetRoom(int id);

        Task<bool> UpdateRoom(Room room);

        Task DeleteRoom(Room room);
    }
}
