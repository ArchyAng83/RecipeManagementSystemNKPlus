using Microsoft.EntityFrameworkCore;
using RecipeManagementSystemNKPlus.Application.DTOs;
using RecipeManagementSystemNKPlus.Application.Interfaces;
using RecipeManagementSystemNKPlus.Domain.Entities;
using RecipeManagementSystemNKPlus.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagementSystemNKPlus.Infrastructure.Repositories
{
    public class ProductRepository(RecipeDbContext context) : IGenericOwnedRepository<Product>
    {
        public Task<GeneralResponse> AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync() => await context.Products.ToListAsync();

        public async Task<Product?> GetByIdAsync(int id) =>
            await context.Products
            .Include(p => p.Composites)
            .ThenInclude(c => c.CompositeType)
            .Include(p => p.Composites)
            .ThenInclude(c => c.Ingredient)
            .Where(p => p.Composites.Any())
            .FirstOrDefaultAsync(i => i.Id == id);

        //var query = from c in context.Composites
        //join p in context.Products on c.ProductId equals p.Id
        //join ct in context.CompositeTypes on c.CompositeTypeId equals ct.Id
        //join i in context.Ingredients on c.IngredientId equals i.Id
        //select new
        //{
        //    ProductId = c.ProductId,
        //    ProductName = p.Name,
        //    CompositeTypeName = ct.Name,
        //    IngredientName = i.Name,
        //    Weight = c.Weight
        //};


        public Task<GeneralResponse> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
