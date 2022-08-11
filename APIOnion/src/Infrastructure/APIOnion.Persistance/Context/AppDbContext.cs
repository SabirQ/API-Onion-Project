using APIOnion.Domain.Entities;
using APIOnion.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Persistance.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantCategory> PlantCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PlantConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
