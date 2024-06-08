using Microsoft.EntityFrameworkCore;

namespace APIAndreVeiculosMicrosservicos.Car.Data
{
    public class APIAndreVeiculosMicrosservicosCarContext : DbContext
    {
        public APIAndreVeiculosMicrosservicosCarContext (DbContextOptions<APIAndreVeiculosMicrosservicosCarContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Car> Car { get; set; } = default!;
    }
}