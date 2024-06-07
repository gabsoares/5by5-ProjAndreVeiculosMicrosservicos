using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIAndreVeiculosMicrosservicos.Purchase.Data
{
    public class APIAndreVeiculosMicrosservicosPurchaseContext : DbContext
    {
        public APIAndreVeiculosMicrosservicosPurchaseContext (DbContextOptions<APIAndreVeiculosMicrosservicosPurchaseContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Purchase> Purchase { get; set; } = default!;
    }
}
