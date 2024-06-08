using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIAndreVeiculosMicrosservicos.Employee.Data
{
    public class APIAndreVeiculosMicrosservicosEmployeeContext : DbContext
    {
        public APIAndreVeiculosMicrosservicosEmployeeContext (DbContextOptions<APIAndreVeiculosMicrosservicosEmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Employee> Employee { get; set; } = default!;
        public DbSet<Models.Role> Role { get; set; } = default!;
        public DbSet<Models.Adress> Adress { get; set; } = default!;
    }
}
