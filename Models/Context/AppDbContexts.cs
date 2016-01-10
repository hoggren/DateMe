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
        public DbSet<Message> Messages { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public System.Data.Entity.DbSet<Friend> Friends { get; set; }
    }
}