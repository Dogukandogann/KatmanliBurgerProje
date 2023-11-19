using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection;
using KatmanliBurger_DAL.Configurations.Extensions;

namespace KatmanliBurger_DAL.Contexts
{
    public class BurgerDbContext:IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<BurgerGarnitureMapping> BurgerGarnitures { get; set; }
        public DbSet<BurgerMenuMapping> BurgerMenus { get; set; }
        public DbSet<BurgerOrderMapping> BurgerOrders { get; set; }
        public DbSet<ByProduct> ByProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Garniture> Garnitures { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuByProductMapping> MenuByProducts { get; set; }
        public DbSet<MenuOrderMapping> MenuOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderByProductMapping> OrderByProducts { get; set; }
        public DbSet<ParameterDetail> ParameterDetails { get; set; }
        public DbSet<ParameterType> ParameterTypes { get; set; }
        public DbSet<CustomerMessage> CustomerMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O5VMPQK\\SQLEXPRESS;Initial Catalog=KatmanliBurger;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
