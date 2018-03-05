namespace MovieReviewsBackend.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MovieReviewsBackend.Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieReviewsBackend.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieReviewsBackend.Models.ApplicationDbContext context)
        {
            //seeding methods
           SeedUsers(context);
           //SeedRoles(context);
        }

        //seed roles
        private void SeedRoles(ApplicationDbContext context)
        {

            var manager =
             new UserManager<ApplicationUser>(
                 new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            //create roles
            roleManager.Create(new IdentityRole { Name = "Admin" });
            roleManager.Create(new IdentityRole { Name = "User" });

            //asign roles to users
            ApplicationUser admin = manager.FindByEmail("john.k@itsligo.ie");
            if (admin != null)
            {
                manager.AddToRoles(admin.Id, new string[] { "Admin" });
            }
            else
            {
                throw new Exception { Source = "Did not find admin" };
            }

            ApplicationUser user = manager.FindByEmail("S01@itsligo.ie");
            if (user != null)
            {
                manager.AddToRoles(user.Id, new string[] { "User" });
            }
            else
            {
                throw new Exception { Source = "Did not find user" };
            }
            context.SaveChanges();
        }

        //seed users
        private void SeedUsers(ApplicationDbContext context)
        {
            //seeding two applicationUsers
            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                Email = "john.k@itsligo.ie",
                EmailConfirmed = true,
                UserName = "john.k@itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("ITSligo$1"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });

            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                Email = "S01@itsligo.ie",
                EmailConfirmed = true,
                UserName = "S01@itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("ITSligo$2"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });
            context.SaveChanges();
        }

    }
}
