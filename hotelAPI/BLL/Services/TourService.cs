using hotelAPI.BLL.Interfaces;
using hotelAPI.DTOs;
using hotelAPI.Infrastructure.Repositories.Interfaces;
using hotelAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelAPI.BLL.Services
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _repository;

        public TourService(ITourRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ReadTourDTO>> GetAllToursAsync()
        {
            var tours = await _repository.GetAllAsync();
            return tours.Select(MapToReadDTO).ToList();
        }

        public async Task<ReadTourDTO?> GetTourByIdAsync(int id)
        {
            var tour = await _repository.GetByIdAsync(id);
            return tour == null ? null : MapToReadDTO(tour);
        }

        public async Task<ReadTourDTO> CreateTourAsync(CreateTourDTO dto)
        {
            var tour = new Tour
            {
                Name = dto.Name,
                Description = dto.Description,
                Destination = dto.Destination,
                Price = dto.Price,
                DurationDays = dto.DurationDays,
                IncludedItems = dto.IncludedItems
            };

            await _repository.AddAsync(tour);
            return MapToReadDTO(tour); // El objeto ya tiene Id después de SaveChangesAsync
        }

        public async Task<ReadTourDTO?> UpdateTourAsync(UpdateTourDTO dto)
        {
            var existingTour = await _repository.GetByIdAsync(dto.Id);
            if (existingTour == null) return null;

            existingTour.Name = dto.Name;
            existingTour.Description = dto.Description;
            existingTour.Destination = dto.Destination;
            existingTour.Price = dto.Price;
            existingTour.DurationDays = dto.DurationDays;
            existingTour.IncludedItems = dto.IncludedItems;
            existingTour.State = dto.State;

            await _repository.UpdateAsync(existingTour);
            return MapToReadDTO(existingTour);
        }

        public async Task<bool> DeleteTourAsync(int id)
        {
            var existingTour = await _repository.GetByIdAsync(id);
            if (existingTour == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        private ReadTourDTO MapToReadDTO(Tour tour)
        {
            return new ReadTourDTO
            {
                Id = tour.Id,
                Name = tour.Name,
                Description = tour.Description,
                Destination = tour.Destination,
                Price = tour.Price,
                DurationDays = tour.DurationDays,
                IncludedItems = tour.IncludedItems,
                DateCreate = tour.DateCreate,
                State = tour.State
            };
        }
    }
}
