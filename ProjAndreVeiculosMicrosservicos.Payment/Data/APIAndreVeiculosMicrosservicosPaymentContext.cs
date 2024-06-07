using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIAndreVeiculosMicrosservicos.Payment.Data
{
    public class APIAndreVeiculosMicrosservicosPaymentContext : DbContext
    {
        public APIAndreVeiculosMicrosservicosPaymentContext (DbContextOptions<APIAndreVeiculosMicrosservicosPaymentContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Payment> Payment { get; set; } = default!;

        public DbSet<Models.CreditCard>? CreditCard { get; set; }

        public DbSet<Models.Pix>? Pix { get; set; }

        public DbSet<Models.Ticket>? Ticket { get; set; }
    }
}
