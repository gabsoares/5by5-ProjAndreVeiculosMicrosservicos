using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosMicrosservicos.Isurance.Data
{
    public class ProjAndreVeiculosMicrosservicosIsuranceContext : DbContext
    {
        public ProjAndreVeiculosMicrosservicosIsuranceContext (DbContextOptions<ProjAndreVeiculosMicrosservicosIsuranceContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Insurance> Insurance { get; set; } = default!;
    }
}
