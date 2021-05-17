using FabricantesCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FabricantesInfraestructure.Data
{
    public class FabricanteContext : DbContext
    {
        public FabricanteContext(DbContextOptions<FabricanteContext> options) : base(options)
        {
        }
        public DbSet<FabricanteEntity> Fabricantes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
