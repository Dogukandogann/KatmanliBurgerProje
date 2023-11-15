using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DAL.Concretes.EntityFramework;
using KatmanliBurger_DAL.Contexts;
using KatmanliBurger_Service.Service.BurgerGarnitureMappingService;
using KatmanliBurger_Service.Service.BurgerService;
using KatmanliBurger_Service.Service.GarnitureService;

namespace KatmanliBurger_UI
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BurgerDbContext>();
            builder.Services.AddScoped<IBurgerService, BurgerManager>();
            builder.Services.AddScoped<IBurgerDal, EfBurgerDal>();
            builder.Services.AddScoped<IGarnitureDal, EfGarnitureDal>();
            builder.Services.AddScoped<IGarnitureService, GarnitureManager>();

            builder.Services.AddScoped<IBurgerGarnitureMappingDal, EfBurgerGarnitureMappingDal>();
            builder.Services.AddScoped<IBurgerGarnitureMappingService, BurgerGarnitureMappingManager>();

            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}