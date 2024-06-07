using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace _5by5_ProjAndreVeiculosMicrosservicos.Data
{
    public class _5by5_ProjAndreVeiculosMicrosservicosContext : DbContext
    {
        public _5by5_ProjAndreVeiculosMicrosservicosContext (DbContextOptions<_5by5_ProjAndreVeiculosMicrosservicosContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Customer> Customer { get; set; } = default!;
    }
}
