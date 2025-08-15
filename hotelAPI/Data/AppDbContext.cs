using hotelAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace hotelAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tour> Tours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Guardar la configuración en una variable
            var includedItemsProperty = modelBuilder.Entity<Tour>()
                .Property(t => t.IncludedItems)
                .HasConversion(
                    v => string.Join(";", v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
                );

            // Configurar el comparador de valores
            includedItemsProperty.Metadata.SetValueComparer(new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()
            ));

            // Límite de longitud
            includedItemsProperty.HasMaxLength(500);

            // Precisión para el precio
            modelBuilder.Entity<Tour>()
                .Property(t => t.Price)
                .HasPrecision(18, 2);
        }
    }
}