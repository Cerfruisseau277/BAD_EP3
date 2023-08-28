using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using Razor_City_trip.Data.Model;

namespace Razor_City_trip.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category {Id = 1, Name = "Avontuur" }, new Category { Id = 2, Name = "Odyssee" }, new Category { Id = 3, Name = "Exploration" }, new Category { Id = 4, Name = "Camping" });
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }

    }
}
