using Microsoft.EntityFrameworkCore;
using Razor_City_trip.Data;
using Razor_City_trip.Data.Interfaces;
using Razor_City_trip.Data.Model;
using Razor_City_trip.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var connString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(connString));
builder.Services.AddScoped<IItineraryService, ItineraryService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
