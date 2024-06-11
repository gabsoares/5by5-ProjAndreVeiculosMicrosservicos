using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosMicrosservicos.Driver.Data
{
    public class ProjAndreVeiculosMicrosservicosDriverContext : DbContext
    {
        public ProjAndreVeiculosMicrosservicosDriverContext (DbContextOptions<ProjAndreVeiculosMicrosservicosDriverContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Driver> Driver { get; set; } = default!;
    }
}
