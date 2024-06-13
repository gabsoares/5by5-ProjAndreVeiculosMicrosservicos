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
        { }
        public DbSet<Car> Car { get; set; } = default!;
        public DbSet<Financing> Financing { get; set; } = default!;
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee>? Employee { get; set; }
        public DbSet<CarJob>? CarJob { get; set; }
        public DbSet<CreditCard>? CreditCard { get; set; }
        public DbSet<Pix>? Pix { get; set; }
        public DbSet<Ticket>? Ticket { get; set; }
        public DbSet<Role>? Role { get; set; }
        public DbSet<PixType>? PixType { get; set; }
        public DbSet<Purchase>? Purchase { get; set; }
        public DbSet<Job>? Job { get; set; }
        public DbSet<Payment>? Payment { get; set; }
        public DbSet<Adress>? Adress { get; set; }
        public DbSet<Sale>? Sale { get; set; }
        public DbSet<FinancialPending>? FinancialPending { get; set; }
        public DbSet<Dependent>? Dependent { get; set; }
        public DbSet<Insurance>? Insurance { get; set; }
        public DbSet<Driver>? Driver { get; set; }
        public DbSet<Cnh>? Cnh { get; set; }
        public DbSet<CnhCategory>? CnhCategory { get; set; }
    }
}
