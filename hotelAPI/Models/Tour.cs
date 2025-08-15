using System.ComponentModel.DataAnnotations;

namespace hotelAPI.Models
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }

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

        public DateTime DateCreate { get; set; } = DateTime.UtcNow;

        public State State { get; set; } = State.Active;
    }

    public enum State
    {
        Active,
        Inactive,
    }
}
