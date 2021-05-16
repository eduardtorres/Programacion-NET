using Microsoft.EntityFrameworkCore;
using ProductosCore.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProductosInfraestructure.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Producto> Producto { get; set; }        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }        
    }
}
