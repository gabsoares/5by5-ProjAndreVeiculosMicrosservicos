using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIAndreVeiculosMicrosservicos.Adress.Data
{
    public class APIAndreVeiculosMicrosservicosAdressContext : DbContext
    {
        public APIAndreVeiculosMicrosservicosAdressContext (DbContextOptions<APIAndreVeiculosMicrosservicosAdressContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Adress> Adress { get; set; } = default!;
    }
}
