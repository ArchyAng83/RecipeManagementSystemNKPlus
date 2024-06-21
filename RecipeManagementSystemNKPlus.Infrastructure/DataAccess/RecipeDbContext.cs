using Microsoft.EntityFrameworkCore;
using RecipeManagementSystemNKPlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagementSystemNKPlus.Infrastructure.DataAccess
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options)
        {
            
        }

        public DbSet<Composite> Composites { get; set; }
        public DbSet<CompositeType> CompositeTypes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCompositeType> ProductCompositeTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCompositeType>()
                .HasKey(t => new { t.ProductId, t.CompositeTypeId });
        }
    }
}
