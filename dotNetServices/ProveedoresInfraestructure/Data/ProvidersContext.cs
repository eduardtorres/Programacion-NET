using ProveedoresCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProveedoresInfraestructure.Data
{
    public class ProvidersContext : DbContext
    {
        public ProvidersContext(DbContextOptions<ProvidersContext> options) : base(options)
        {
        }
        public DbSet<ProveedorEntity> Proveedores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
