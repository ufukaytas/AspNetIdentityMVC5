using AspNetIdentityMVC5.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AspNetIdentityMVC5.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext()
             : base("DbContextConnectionString", throwIfV1Schema: false)
        {
        }

        static AppDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer(new DatabaseInitializer());
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}