namespace ReservationCaseStudy.Library.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ReservationCaseStudy.Library.ReservationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ReservationCaseStudy.Library.ReservationDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var stations = new List<Station>
            {
                new Station{ Code="MLL", Description="Marshall Airport"},
                new Station{ Code="MLS", Description="Miles City Municipal Airport"},
                new Station{ Code="MOU", Description="Mountain Village Airport Airport"},
                new Station{ Code="MNL", Description="Ninoy Aquino International Airport"},
            };

            stations.ForEach(s => context.Stations.AddOrUpdate(v => v.Code, s));
            context.SaveChanges();
        }
    }
}
