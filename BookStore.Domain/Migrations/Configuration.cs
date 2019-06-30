namespace BookStore.Domain.Migrations
{
    using BookStore.Domain.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStore.Domain.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BookStore.Domain.ApplicationDbContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Check to see if Role Exists, if not create it
            var role = new IdentityRole("Admin");
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(role);
            }

            if (!userManager.Users.Any(x => x.Email == "admin@mail.com"))
            {
                var user = new User
                {
                    Email = "admin@mail.com",
                    UserName = "admin@mail.com"
                };
                userManager.Create(user, "123456");
                userManager.AddToRole(user.Id, role.Name);
            }

        }
    }
}
