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
        public DbSet<ProductComposite> ProductComposite { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Product>()
            .HasMany(c => c.Composites)
            .WithMany(s => s.Products)
            .UsingEntity<ProductComposite>(
               j => j
                .HasOne(pt => pt.Composite)
                .WithMany(t => t.ProductComposites)
                .HasForeignKey(pt => pt.CompositeId),
            j => j
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductComposites)
                .HasForeignKey(pt => pt.ProductId),
            j => j.HasKey(t => new { t.ProductId, t.CompositeId }));

            modelBuilder
            .Entity<CompositeType>()
            .HasMany(c => c.Ingredients)
            .WithMany(s => s.CompositeTypes)
            .UsingEntity<Composite>(
               j => j
                .HasOne(pt => pt.Ingredient)
                .WithMany(t => t.Composites)
                .HasForeignKey(pt => pt.IngredientId),
            j => j
                .HasOne(pt => pt.CompositeType)
                .WithMany(p => p.Composites)
                .HasForeignKey(pt => pt.CompositeTypeId),
            j => j.HasKey(t => t.Id));
        }
    }
}
