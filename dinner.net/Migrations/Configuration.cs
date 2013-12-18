namespace dinner.net.Migrations
{
    using dinner.net.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<dinner.net.DAL.DinnerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "dinner.net.DAL.DinnerContext";
        }

        protected override void Seed(dinner.net.DAL.DinnerContext context)
        {
            context.Ingredients.AddOrUpdate(
                new Ingredient { Name = "Onion" },
                new Ingredient { Name = "Large can tomato sauce", ExtendedDescription = "15oz"}
            );



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
        }
    }
}
