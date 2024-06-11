using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosMicrosserv.FinancialPending.Data
{
    public class ProjAndreVeiculosMicrosservFinancialPendingContext : DbContext
    {
        public ProjAndreVeiculosMicrosservFinancialPendingContext (DbContextOptions<ProjAndreVeiculosMicrosservFinancialPendingContext> options)
            : base(options)
        {
        }

        public DbSet<Models.FinancialPending> FinancialPending { get; set; } = default!;
    }
}
