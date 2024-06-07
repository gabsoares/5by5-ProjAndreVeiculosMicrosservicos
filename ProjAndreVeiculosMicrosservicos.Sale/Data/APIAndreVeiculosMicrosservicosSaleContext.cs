using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIAndreVeiculosMicrosservicos.Sale.Data
{
    public class APIAndreVeiculosMicrosservicosSaleContext : DbContext
    {
        public APIAndreVeiculosMicrosservicosSaleContext (DbContextOptions<APIAndreVeiculosMicrosservicosSaleContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Sale> Sale { get; set; } = default!;
    }
}
