using hotelAPI.Data;
using hotelAPI.Infrastructure.Repositories.Interfaces;
using hotelAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotelAPI.Infrastructure.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly ApplicationDbContext _context;

        public TourRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tour>> GetAllAsync()
        {
            return await _context.Tours.ToListAsync();
        }

        public async Task<Tour?> GetByIdAsync(int id)
        {
            return await _context.Tours.FindAsync(id);
        }

        public async Task AddAsync(Tour tour)
        {
            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tour tour)
        {
            _context.Tours.Update(tour);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
                return false;

            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
