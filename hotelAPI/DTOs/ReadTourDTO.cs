using hotelAPI.Models;

namespace hotelAPI.DTOs
{
    public class ReadTourDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public List<string> IncludedItems { get; set; } = new List<string>();
        public DateTime DateCreate { get; set; }
        public State State { get; set; }
    }
}
