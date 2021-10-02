using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace ProjectAssigned.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string JoinDate { get;set; }
        public string CV { get;set; }
        public string Photo { get; set; }
        public string Experience { get;set; }
        public bool? IsActive { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        public string Bio { get; set;  }
      
        public string Salary { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }


    public class GenericModel
    {
      public  ProjectAssignedEntities db = new ProjectAssignedEntities();
        public AspNetUser FetchUserProfile()
        {
            string id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            return db.AspNetUsers.FirstOrDefault(x => x.Id == id);
        }
    }

}