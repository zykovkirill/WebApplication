using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebService.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ElectricityMeasuringPoint> ElectricityMeasuringPoints { get; set; }
        public DbSet<Measurer> Measurers { get; set; }
        public DbSet<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; }
        public DbSet<CalculatingMeteringDevice> CalculatingMeteringDevices { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Сonsumer> Сonsumers { get; set; }
        public DbSet<Transformer> Transformers { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            
        }
    }
}
