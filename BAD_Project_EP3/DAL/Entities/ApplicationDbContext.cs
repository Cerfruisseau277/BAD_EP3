using System;
using System.Collections.Generic;
using DAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities;

public partial class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarSharingDB;Trusted_Connection=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasData(new User() {Id = "94016c50-8d53-4014-a363-7c4b84d4e29b", Firstname = "Abdelhafid", LastName = "Khanfous"});
        modelBuilder.Entity<Car>().HasData(
            new Car() { Id = 1, Brand = "Volvo", Model = "V90", Description = "Luxueuse Break", Year = 2022, Seats = 5, FuelType = FuelType.Diesel, Transmission = Transmission.Automatic, ImageURL = "https://abdomeincerf2.be/img/volvoV90.png", OwnerId = "94016c50-8d53-4014-a363-7c4b84d4e29b"},
            new Car() { Id = 2, Brand = "Skoda", Model = "Superb", Description = "Family & Comfotable Break", Year = 2021, Seats = 5, FuelType = FuelType.Petrol, Transmission = Transmission.Manual, ImageURL = "https://abdomeincerf2.be/img/SkodaS.png", OwnerId = "94016c50-8d53-4014-a363-7c4b84d4e29b" }
            );
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Borrowing> Borrowings { get; set; }
}
