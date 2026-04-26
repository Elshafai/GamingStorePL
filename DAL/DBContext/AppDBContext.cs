using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action" },
                new Category { Id = 2, Name = "Adventure" },
                new Category { Id = 3, Name = "RPG" },
                new Category { Id = 4, Name = "Sports" });

            // Seed Devices
            modelBuilder.Entity<Device>().HasData(
                new Device { Id = 1, Name = "PC", Icon = "pc_icon.png" },
                new Device { Id = 2, Name = "PS4", Icon = "ps4_icon.png" },
                new Device { Id = 3, Name = "PS5", Icon = "ps5_icon.png" },
                new Device { Id = 4, Name = "Xbox", Icon = "xbox_icon.png" }
            );
        }
    }
}
