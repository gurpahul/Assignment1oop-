namespace Assignment1Gurpahul.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Assignment1Gurpahul.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment1Gurpahul.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Roles.Any(r => r.Name == "User1"))
            {
                roleManager.Create(new IdentityRole { Name = "User1" });

                ApplicationUser adminUser = null;
                if (!context.Users.Any(p => p.UserName == "admin@myblogapp.com"))
                {
                    adminUser = new ApplicationUser();
                    adminUser.UserName = "admin@myblogapp.com";
                    adminUser.Email = "admin@myblogapp.com";
                    userManager.Create(adminUser, "Mypass-2");
                }
                else
                {
                    adminUser = context.Users.Where(p => p.UserName == "admin@myblogapp.com")
                        .FirstOrDefault();
                }
                //Check if the adminUser is already on the Admin role
                //If not, add it.
                if (!userManager.IsInRole(adminUser.Id, "User1"))
                {
                    userManager.AddToRole(adminUser.Id, "User1");
                }
            }

        }
    }
}
