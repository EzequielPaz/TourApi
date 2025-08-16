using hotelAPI.Models;

namespace hotelAPI.Infrastructure.Repositories.Interfaces
{
    public interface ITourRepository
    {
        Task<List<Tour>> GetAllAsync();
        Task<Tour> GetByIdAsync(int id);
        Task AddAsync(Tour tour);
        Task UpdateAsync(Tour tour);
        Task<bool> DeleteAsync(int id);
    }
}
