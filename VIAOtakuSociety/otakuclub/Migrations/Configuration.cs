namespace OtakuClub.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OtakuClub.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<OtakuClub.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OtakuClub.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            AddUserAndRole(context);
            context.Animes.AddOrUpdate(p => p.title,
                new Anime
                {
                    title = "Koutetsujou no Kabaneri - Kabaneri of the Iron Fortress",
                    imageLink = "http://anilist.co/img/dir/anime/reg/21196-0dhwtTGZwTYg.jpg",
                    start = new DateTime(2016, 5, 22, 17, 0, 0),
                    end = new DateTime(2016, 5, 22, 20, 0, 0),
                },
            new Anime
            {
                title = "Kiznaiver",
                imageLink = "http://anilist.co/img/dir/anime/reg/21421-SVOHkopCzGL2.jpg",
                start = new DateTime(2016, 5, 29, 17, 0, 0),
                end = new DateTime(2016, 5, 29, 20, 0, 0),
            });
        }

        bool AddUserAndRole(OtakuClub.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));

            ir = rm.Create(new IdentityRole("canEdit"));

            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser()
            {
                UserName = "admin@admin.com",
            };

            ir = um.Create(user, "P_ssword1");

            if (ir.Succeeded == false)
                return ir.Succeeded;

            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }
    }
}
