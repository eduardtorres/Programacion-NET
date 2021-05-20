using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OrdenesCore.Entities;

namespace OrdenesInfraestructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<DetalleOrdenes> DetalleOrden { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
