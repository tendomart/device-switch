using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeControlApi.Models;

    public class LightsContextContext : DbContext
    {
        public LightsContextContext (DbContextOptions<LightsContextContext> options)
            : base(options)
        {
        }

        public DbSet<HomeControlApi.Models.Light> Light { get; set; } = default!;

         protected override void OnModelCreating(ModelBuilder builder)
         {
            builder.Entity<Light>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Light>().Property(p => p.Name).HasMaxLength(30);
            builder.Entity<Light>().Property(p => p.LightOn);
         }
    }
