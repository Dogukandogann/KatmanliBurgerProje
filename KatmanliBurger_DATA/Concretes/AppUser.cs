using Microsoft.AspNetCore.Identity;

namespace KatmanliBurger_DATA.Concretes
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
        public AppUser()
        {
            Orders = new HashSet<Order>();
        }
    }
}
