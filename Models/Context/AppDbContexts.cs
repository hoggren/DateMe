using Microsoft.AspNet.Identity.EntityFramework;
using Models.Models;
using System.Data.Entity;

namespace Models.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext() : base("DefaultConnection")
        {
           Database.SetInitializer(new AppDbInitializer());
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}