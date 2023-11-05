using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AzureSamples.Models;

    public class AzureSamplesCosmosDBContext : DbContext
    {
        public AzureSamplesCosmosDBContext (DbContextOptions<AzureSamplesCosmosDBContext> options)
            : base(options)
        {
        }

        public DbSet<AzureSamples.Models.Employee> Employee { get; set; } = default!;

        public DbSet<AzureSamples.Models.BlobModel>? BlobModel { get; set; }
    }
