using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gruppe5.Models;

namespace Gruppe5.Data
{
    public class Gruppe5Context : DbContext
    {
        public Gruppe5Context(DbContextOptions<Gruppe5Context> options)
            : base(options)
        {
        }

        public DbSet<Gruppe5.Models.WeatherForecast> WeatherForecast { get; set; } = default!;
        public DbSet<Gruppe5.Models.Observation> Observation { get; set; } = default!;
        public DbSet<Gruppe5.Models.RootObject> RootObject { get; set; } = default!;
        public DbSet<Gruppe5.Models.Level> Level { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfigurer Level som en keyless enhet
            modelBuilder.Entity<Level>().HasNoKey();
        }

    }
}