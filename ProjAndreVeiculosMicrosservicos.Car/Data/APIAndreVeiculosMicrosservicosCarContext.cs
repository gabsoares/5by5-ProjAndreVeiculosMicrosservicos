using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

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
