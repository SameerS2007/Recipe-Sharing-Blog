using System;
using Microsoft.EntityFrameworkCore;

namespace RecipeSharingSite.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasMany(r => r.Contents).WithOne(d => d.Recipe);
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<RecipeContent> RecipeContent { get; set; }

    }
}
