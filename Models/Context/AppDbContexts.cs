using Microsoft.AspNet.Identity.EntityFramework;
using Models.Models;

namespace Models.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext() : base("DefaultConnection")
        {
            
        }


    }
}