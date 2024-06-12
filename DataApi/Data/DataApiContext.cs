using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataApi.Data
{
    public class DataApiContext : DbContext
    {
        public DataApiContext (DbContextOptions<DataApiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Car> Car { get; set; } = default!;
        public DbSet<Models.Customer> Customer { get; set; }
        public DbSet<Models.Employee>? Employee { get; set; }
        public DbSet<Models.CarJob>? CarJob { get; set; }
        public DbSet<Models.CreditCard>? CreditCard { get; set; }
        public DbSet<Models.Pix>? Pix { get; set; }
        public DbSet<Models.Ticket>? Ticket { get; set; }
        public DbSet<Models.Role>? Role { get; set; }
        public DbSet<Models.PixType>? PixType { get; set; }
        public DbSet<Models.Purchase>? Purchase { get; set; }
        public DbSet<Models.Job>? Job { get; set; }
        public DbSet<Models.Payment>? Payment { get; set; }
        public DbSet<Models.Adress>? Adress { get; set; }
        public DbSet<Models.Sale>? Sale { get; set; }
        public DbSet<Models.FinancialPending>? FinancialPending { get; set; }
        public DbSet<Models.Financing>? Financing { get; set; }
        public DbSet<Models.Dependent>? Dependent { get; set; }
        public DbSet<Models.Insurance>? Insurance { get; set; }
        public DbSet<Models.Driver>? Driver { get; set; }
        public DbSet<Models.Cnh>? Cnh { get; set; }
        public DbSet<Models.CnhCategory>? CnhCategory { get; set; }
    }               
}
