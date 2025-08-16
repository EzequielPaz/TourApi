using System.ComponentModel.DataAnnotations;

namespace hotelAPI.DTOs
{
    public class CreateTourDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [MaxLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "El destino es obligatorio")]
        [MaxLength(100)]
        public string Destination { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public int DurationDays { get; set; }

        public List<string> IncludedItems { get; set; } = new List<string>();
    }
}

