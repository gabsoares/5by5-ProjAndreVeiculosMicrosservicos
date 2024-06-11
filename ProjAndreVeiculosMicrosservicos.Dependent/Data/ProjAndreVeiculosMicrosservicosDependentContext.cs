﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosMicrosservicos.Dependent.Data
{
    public class ProjAndreVeiculosMicrosservicosDependentContext : DbContext
    {
        public ProjAndreVeiculosMicrosservicosDependentContext (DbContextOptions<ProjAndreVeiculosMicrosservicosDependentContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Dependent> Dependent { get; set; } = default!;
    }
}
