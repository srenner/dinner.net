using dinner.net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace dinner.net.DAL
{
    public class DinnerContext : DbContext
    {
        public DinnerContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Ingredient> Ingredients { get; set; }

        public System.Data.Entity.DbSet<dinner.net.Models.Meal> Meals { get; set; }
    }
}