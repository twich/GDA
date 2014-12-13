using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<WebApplication1.Models.State> States { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Industry> Industry { get; set; }
    }

    public class ApplicationDbIntializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.States.Add(new State { StateName = "Alabama" });
            context.States.Add(new State { StateName = "Alaska" });
            context.States.Add(new State { StateName = "Arizona" });
            context.States.Add(new State { StateName = "Arkansas" });
            context.States.Add(new State { StateName = "California" });
            context.States.Add(new State { StateName = "Colorado" });
            context.States.Add(new State { StateName = "Connecticut" });
            context.States.Add(new State { StateName = "Delaware" });
            context.States.Add(new State { StateName = "District Of Columbia" });
            context.States.Add(new State { StateName = "Florida" });
            context.States.Add(new State { StateName = "Georgia" });
            context.States.Add(new State { StateName = "Hawaii" });
            context.States.Add(new State { StateName = "Idaho" });
            context.States.Add(new State { StateName = "Illinois" });
            context.States.Add(new State { StateName = "Indiana" });
            context.States.Add(new State { StateName = "Iowa" });
            context.States.Add(new State { StateName = "Kansas" });
            context.States.Add(new State { StateName = "Kentucky" });
            context.States.Add(new State { StateName = "Louisiana" });
            context.States.Add(new State { StateName = "Maine" });
            context.States.Add(new State { StateName = "Maryland" });
            context.States.Add(new State { StateName = "Massachusetts" });
            context.States.Add(new State { StateName = "Michigan" });
            context.States.Add(new State { StateName = "Minnesota" });
            context.States.Add(new State { StateName = "Mississippi" });
            context.States.Add(new State { StateName = "Missouri" });
            context.States.Add(new State { StateName = "Montana" });
            context.States.Add(new State { StateName = "Nebraska" });
            context.States.Add(new State { StateName = "Nevada" });
            context.States.Add(new State { StateName = "New Hampshire" });
            context.States.Add(new State { StateName = "New Jersey" });
            context.States.Add(new State { StateName = "New Mexico" });
            context.States.Add(new State { StateName = "New York" });
            context.States.Add(new State { StateName = "North Carolina" });
            context.States.Add(new State { StateName = "North Dakota" });
            context.States.Add(new State { StateName = "Ohio" });
            context.States.Add(new State { StateName = "Oklahoma" });
            context.States.Add(new State { StateName = "Oregon" });
            context.States.Add(new State { StateName = "Pennsylvania" });
            context.States.Add(new State { StateName = "Rhode Island" });
            context.States.Add(new State { StateName = "South Carolina" });
            context.States.Add(new State { StateName = "South Dakota" });
            context.States.Add(new State { StateName = "Tennessee" });
            context.States.Add(new State { StateName = "Texas" });
            context.States.Add(new State { StateName = "Utah" });
            context.States.Add(new State { StateName = "Vermont" });
            context.States.Add(new State { StateName = "Virginia" });
            context.States.Add(new State { StateName = "Washington" });
            context.States.Add(new State { StateName = "West Virginia" });
            context.States.Add(new State { StateName = "Wisconsin" });
            context.States.Add(new State { StateName = "Wyoming" });
            base.Seed(context);
        }
    }
}