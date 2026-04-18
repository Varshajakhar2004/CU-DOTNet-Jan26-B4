using Microsoft.EntityFrameworkCore;
using NorthwindCatalog.Services.Mappings;
using NorthwindCatalog.Services.Models;
using NorthwindCatalog.Services.Repositories;
using NorthwindCatalog.Web.Repositories;

namespace NorthwindCatalog.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // MVC
            builder.Services.AddControllersWithViews();

            // DB Context
            builder.Services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            // Repositories
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            // AutoMapper (FIXED)
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // HttpClient for API
            builder.Services.AddHttpClient("api", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7094/");
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Categories}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}