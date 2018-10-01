using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetIdentityMVC5.Managers;
using Microsoft.AspNet.Identity;

namespace AspNetIdentityMVC5.Entities
{
    public class User : IdentityUser
    {
        public User()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get { return string.Join(" ", FirstName, LastName); } }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one 
            // defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity =
                await manager.CreateIdentityAsync(this,
                    DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}