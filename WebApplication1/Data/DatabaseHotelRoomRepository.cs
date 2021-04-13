using WebApplication1.Data.Interfaces;

namespace WebApplication1.Data
{
    public class DatabaseHotelRoomRepository : IHotelRoomRepository
    {
        public DatabaseHotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        private readonly AsyncInnDbContext _context;
    }
}
