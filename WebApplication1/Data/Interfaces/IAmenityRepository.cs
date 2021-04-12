using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data.Interfaces
{
    public interface IAmenityRepository
    {
        Task<IEnumerable<Amenity>> GetAllAmenities();

        Task CreateAmenity(Amenity amenity);

        Task<Amenity> GetAmenity(int id);

        Task<bool> UpdateAmenity(Amenity amenity);

        Task DeleteAmenity(Amenity amenity);
    }
}