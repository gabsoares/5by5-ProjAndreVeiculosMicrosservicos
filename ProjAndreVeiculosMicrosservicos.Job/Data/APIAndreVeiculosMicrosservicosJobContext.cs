using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIAndreVeiculosMicrosservicos.Job.Data
{
    public class APIAndreVeiculosMicrosservicosJobContext : DbContext
    {
        public APIAndreVeiculosMicrosservicosJobContext (DbContextOptions<APIAndreVeiculosMicrosservicosJobContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Job> Job { get; set; } = default!;
    }
}
