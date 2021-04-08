using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DatabaseAmenityRepository : IAmenityRepository
    {
        private readonly AsyncInnDbContext _context;
        public DatabaseAmenityRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task CreateAmenity(Amenity amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAmenity(Amenity amenity)
        {
            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Amenity>> GetAllAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenity> GetAmenity(int id)
        {
            return await _context.Amenities.FindAsync(id);
        }

        public async Task<bool> UpdateAmenity(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Save worked
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenityExists(amenity.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool AmenityExists(int id)
        {
            return _context.Amenities.Any(e => e.Id == id);
        }

    }
}