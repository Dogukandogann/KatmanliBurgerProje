using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DAL.Concretes.EntityFramework;
using KatmanliBurger_DAL.Contexts;
using KatmanliBurger_Service.Service.BurgerGarnitureMappingService;
using KatmanliBurger_Service.Service.BurgerService;
using KatmanliBurger_Service.Service.ByProductService;
using KatmanliBurger_Service.Service.CategoryService;
using KatmanliBurger_Service.Service.GarnitureService;
using KatmanliBurger_Service.Service.MenuService;
using System.Reflection;

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
			builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
			builder.Services.AddScoped<IBurgerService, BurgerManager>();
            builder.Services.AddScoped<IMenuService, MenuManager>();
            builder.Services.AddScoped<IMenuDal, EfMenuDal>();

            builder.Services.AddScoped<IByProductDal, EfByProductDal>();
            builder.Services.AddScoped<IByProductService, ByProductManager>();

            builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
            builder.Services.AddScoped<ICategoryService, CategoryManager>();



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
			app.MapControllers();

			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}