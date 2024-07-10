using System;
using System.Data.Entity.Migrations;

namespace $safeprojectname$.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<$customAPPLICATION$DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed($customAPPLICATION$DbContext context)
        {
            Console.WriteLine("Seed()");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // This Seeds Address, Customer, and Material

            SeedInitialDatabaseTables(context);
            base.Seed(context);
        }

        void SeedInitialDatabaseTables($customAPPLICATION$DbContext context)
        {
            context.$customTYPE$Set.AddOrUpdate(
                i => i.Id,
                new Domain.$customTYPE$
                {
                    Id = 1,
                    FieldString = "String1",
                    FieldInt = 41,
                    FieldDouble = 41.41
                },
                new Domain.$customTYPE$
                {
                    Id = 2,
                    FieldString = "String2",
                    FieldInt = 42,
                    FieldDouble = 42.42
                });
        }


    }
}
