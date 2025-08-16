using hotelAPI.DTOs;

namespace hotelAPI.BLL.Interfaces
{
    public interface ITourService
    {
        Task<List<ReadTourDTO>> GetAllToursAsync();
        Task<ReadTourDTO?> GetTourByIdAsync(int id);
        Task<ReadTourDTO> CreateTourAsync(CreateTourDTO dto);
        Task<ReadTourDTO?> UpdateTourAsync(UpdateTourDTO dto);
        Task<bool> DeleteTourAsync(int id);

    }
}
