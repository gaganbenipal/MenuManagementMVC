using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MenuManagementMVC.Models.UserDefined;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MenuManagementMVC.Context
{
    public class RecipeContext : DbContext
    {
     
        /// <summary>
        /// Seems like this is required when we take userid as foriegn key
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }


        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Unit> Units { get; set; }
        public System.Data.Entity.DbSet<MenuManagementMVC.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}