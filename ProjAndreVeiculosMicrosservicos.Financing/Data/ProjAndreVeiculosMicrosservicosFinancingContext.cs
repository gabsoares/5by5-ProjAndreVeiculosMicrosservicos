using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosMicrosservicos.Financing.Data
{
    public class ProjAndreVeiculosMicrosservicosFinancingContext : DbContext
    {
        public ProjAndreVeiculosMicrosservicosFinancingContext (DbContextOptions<ProjAndreVeiculosMicrosservicosFinancingContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Financing> Financing { get; set; } = default!;
    }
}
