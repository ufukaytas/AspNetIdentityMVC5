using AspNetIdentityMVC5.Entities;
using AspNetIdentityMVC5.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Web;

namespace AspNetIdentityMVC5.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        public static void InitializeIdentityForEF(AppDbContext context)
        {
            var currentContext = HttpContext.Current;

            var ctx = currentContext.GetOwinContext();


            AppUserManager userManager = ctx.Get<AppUserManager>();
            AppRoleManager roleManager = ctx.Get<AppRoleManager>();

            string roleName = "Administrator";
            string firstName = "ufuk";
            string lastName = "aytas";
            string email = "admin@admin.com";
            string password = "123123";

            var role = roleManager.FindByName(roleName);

            if (role == null)
            {
                role = new Role
                {
                    Name = roleName
                };

                roleManager.Create(role);
            }

           
             
            User user = userManager.FindByName(email);

            if (user == null)
            {

                user = new User
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    FirstName = firstName,
                    LastName = lastName
                };

                userManager.Create(user, password);

                userManager.SetLockoutEnabled(user.Id, false); 
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);

            if (!rolesForUser.Contains(roleName))
                userManager.AddToRole(user.Id, roleName);
        }
    }
}