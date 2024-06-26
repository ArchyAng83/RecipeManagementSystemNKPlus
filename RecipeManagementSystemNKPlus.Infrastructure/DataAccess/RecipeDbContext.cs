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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(ct => ct.CompositeTypes)
                .WithMany(p => p.Products)
                .UsingEntity<Composite>(
                    j => j
                    .HasOne(ct => ct.CompositeType)
                    .WithMany(c => c.Composites)
                    .HasForeignKey(ct => ct.CompositeTypeId),
                    j => j
                    .HasOne(p => p.Product)
                    .WithMany(c => c.Composites)
                    .HasForeignKey(p => p.ProductId)
                );

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
                .HasForeignKey(pt => pt.CompositeTypeId));

            modelBuilder
                .Entity<Composite>()
                .HasKey(k => new {k.ProductId, k.CompositeTypeId, k.IngredientId});
        }
    }
}
