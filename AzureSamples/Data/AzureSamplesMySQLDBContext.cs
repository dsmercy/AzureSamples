using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AzureSamples.Models;

    public class AzureSamplesMySQLDBContext : DbContext
    {
        public AzureSamplesMySQLDBContext (DbContextOptions<AzureSamplesMySQLDBContext> options)
            : base(options)
        {
        }

        public DbSet<AzureSamples.Models.Employee> Employee { get; set; } = default!;
    }
