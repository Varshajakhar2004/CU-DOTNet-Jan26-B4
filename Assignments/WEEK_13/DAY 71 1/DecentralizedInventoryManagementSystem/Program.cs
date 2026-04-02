using DecentrailzedInventoryManagementSystem.Models;
using DecentralizedInventoryManagementSystem.Repositories;
using DecentralizedInventoryManagementSystem.Models;
using DecentralizedInventoryManagementSystem.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddScoped<ILaptopRepository, LaptopRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Laptop}/{action=Index}/{id?}");

app.Run();